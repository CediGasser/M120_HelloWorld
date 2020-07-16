using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hello_World.Core;
using Hello_World.Infrastructure.Commands;
using Hello_World.Infrastructure.ViewModels;

namespace Hello_World.Shop
{
    class ShopViewModel : ViewModelBase
    {
        private Game game;

        public ShopViewModel(Game game)
        {
            this.game = game;
            HelloWorldDeviceProducers = game.HelloWorldProducers.Select(device => new DeviceViewModel(this.game, device)).ToList();
        }

        public double Karma
        {
            get => game.Karma;
            set => game.Karma = value;
        }
        
        public List<DeviceViewModel> HelloWorldDeviceProducers { get; }
    }
}
