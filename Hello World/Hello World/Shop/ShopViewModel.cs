using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hello_World.Core;
using Hello_World.Infrastructure.Commands;
using Hello_World.Infrastructure.ViewModels;

namespace Hello_World.Shop
{
    public class ShopViewModel : ViewModelBase
    {
        private Game game;

        public ShopViewModel(Game game)
        {
            this.game = game;
            this.HelloWorldDeviceProducers = game.HelloWorldProducers.Select(device => new DeviceViewModel(this.game, device)).ToList();
        }

        public double Karma
        {
            get => game.Karma;
            set => game.Karma = value;
        }
        
        public List<DeviceViewModel> HelloWorldDeviceProducers { get; }

        public bool IsWindowClosed { get; internal set; } = true;

        public event EventHandler BringToFrontRequested;
        
        public event EventHandler CloseRequested;

        public void RequestClose()
        {
            this.OnCloseRequested();
        }

        protected virtual void OnCloseRequested()
        {
            this.CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        public void RequestBringToFront()
        {
            this.OnBringToFrontRequested();
        }

        protected virtual void OnBringToFrontRequested()
        {
            this.BringToFrontRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
