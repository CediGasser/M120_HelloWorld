using Hello_World.Core;
using Hello_World.Infrastructure.Commands;

namespace Hello_World.Shop
{
    public class DeviceViewModel
    {
        private readonly Game game;

        public DeviceViewModel(Game parentGame, Device device)
        {
            this.Device = device;
            this.game = parentGame;
            this.OnBuyButtonClickCommand = new RelayCommand(this.OnBuyButtonClick);
        }

        public Device Device { get; }

        // ReSharper disable once MemberCanBePrivate.Global
        public RelayCommand OnBuyButtonClickCommand { get; set; }

        private void OnBuyButtonClick()
        {
            this.BuyDevice();
        }

        private void BuyDevice()
        {
            this.game.TryBuyHelloWorldProducer(this.Device);
        }
    }
}