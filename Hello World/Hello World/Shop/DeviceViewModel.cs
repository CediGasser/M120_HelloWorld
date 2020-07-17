using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Hello_World.Core;
using Hello_World.Infrastructure.Commands;

namespace Hello_World.Shop
{
    public class DeviceViewModel
    {
        private Game game;

        public DeviceViewModel(Game parentGame, Device device)
        {
            this.Device = device;
            this.game = parentGame;
            OnBuyButtonClickCommand = new RelayCommand(OnBuyButtonClick);

        }

        public Device Device { get;}

        public RelayCommand OnBuyButtonClickCommand { get; set; }

        private void OnBuyButtonClick()
        {
            BuyDevice();
        }

        private void BuyDevice()
        {
              game.TryBuyHelloWorldProducer(Device);
        }
    }
}
