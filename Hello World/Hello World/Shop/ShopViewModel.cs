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
    public sealed class ShopViewModel : ViewModelBase, IClosable
    {

        public ShopViewModel(Game game)
        {
            this.HelloWorldDeviceProducers = game.HelloWorldProducers.Select(device => new DeviceViewModel(game, device)).ToList();
        }

        public List<DeviceViewModel> HelloWorldDeviceProducers { get; }

        public bool IsWindowClosed { get; internal set; } = true;

        public event EventHandler BringToFrontRequested;
        
        public event EventHandler CloseRequested;


        private void OnCloseRequested()
        {
            this.CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        public void RequestBringToFront()
        {
            this.OnBringToFrontRequested();
        }

        private void OnBringToFrontRequested()
        {
            this.BringToFrontRequested?.Invoke(this, EventArgs.Empty);
        }
        public void RequestClose()
        {
            this.OnCloseRequested();
        }
    }
}
