using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hello_World.Core;
using Hello_World.Infrastructure;
using Hello_World.Infrastructure.Commands;
using Hello_World.Infrastructure.ViewModels;

namespace Hello_World.Shop
{
    public class ShopViewModel : ViewModelBase, IClosable
    {
        private Game game;

        public ShopViewModel(Game game)
        {
            this.game = game;
            this.HelloWorldDeviceProducers = game.HelloWorldProducers.Select(device => new DeviceViewModel(this.game, device)).ToList();
        }

        public List<DeviceViewModel> HelloWorldDeviceProducers { get; }

        public bool IsWindowClosed { get; internal set; } = true;

        public event EventHandler BringToFrontRequested;
        
        public event EventHandler CloseRequested;


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
        public void RequestClose()
        {
            OnCloseRequested();
        }
    }
}
