using System;
using System.Linq;
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
            oneSecondTimer.DispatcherTimer.Tick += OnTimerEnd;
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
            PrintHelloWorld();
            UpdateKarma(1);
            UpdateClicksPerSecond(1);
        }

        private void OnTimerEnd(object sender, EventArgs e)
        {
            int allHelloWorldPerSecond = CalculateAllAutomaticHelloWorldPerSecond();
            RefreshHelloWorldPerSecond();
            UpdateKarma(allHelloWorldPerSecond);
            UpdateHelloWorldPerSecond(allHelloWorldPerSecond);
        }

        private void UpdateClicksPerSecond(int newClicks)
        {
            clicksPerSecond += newClicks;
        }

        private void RefreshHelloWorldPerSecond()
        {
            this.HelloWorldPerSecond = this.clicksPerSecond;
            this.clicksPerSecond = 0;
        }

        private void UpdateKarma(int newHelloWorldCount)
        {
            this.Karma += newHelloWorldCount;
        }

        private void UpdateHelloWorldPerSecond(int newHelloWorldCount)
        {
            this.HelloWorldPerSecond += newHelloWorldCount;
        }

        private void PrintHelloWorld()
        {
            this.TextBoxText += $"{Environment.NewLine}{TextToPrint}";
        }

        private int CalculateAllAutomaticHelloWorldPerSecond()
        {
            int allAutomaticHelloWorldsPerSecond = 0;

            if (game.HelloWorldProducers != null)
            {
                foreach (Device device in this.game.HelloWorldProducers)
                {
                    allAutomaticHelloWorldsPerSecond += device.HelloWorldPerSecond;
                }
            }
            return allAutomaticHelloWorldsPerSecond;
        }
    }
}