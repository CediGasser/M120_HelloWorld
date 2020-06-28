using System;
using Hello_World.Core;
using Hello_World.Infrastructure.Commands;
using Hello_World.Infrastructure.Timer;
using Hello_World.Infrastructure.ViewModels;

namespace Hello_World.GamePage
{
    internal class GameViewModel : ViewModelBase
    {
        private readonly Game game;
        private const string TextToPrint = "Hello World";

        private int clicksPerSecond;

        public GameViewModel(Game game)
        {
            this.game = game;
            OnHelloWorldButtonClickCommand = new RelayCommand(OnHelloWorldButtonClick);
            OneSecondTimer oneSecondTimer = new OneSecondTimer();
            oneSecondTimer.dispatcherTimer.Tick += OnTimerEnd;
        }

        public int HelloWorldPerSecond { get; set; }

        public RelayCommand OnHelloWorldButtonClickCommand { get; set; }

        public int Karma
        {
            get => game.Karma;
            set => game.Karma = value;
        }

        public string TextBoxText { get; set; } = TextToPrint;

        private void OnHelloWorldButtonClick()
        {
            Karma += 1;
            clicksPerSecond += 1;
            this.TextBoxText += $"{Environment.NewLine}{TextToPrint}";
        }

        private void OnTimerEnd(object sender, EventArgs e)
        {
            HelloWorldPerSecond = clicksPerSecond;
            clicksPerSecond = 0;
        }
    }
}