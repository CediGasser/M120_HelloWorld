using System;
using System.Linq;
using Hello_World.Core;
using Hello_World.Infrastructure.Commands;
using Hello_World.Infrastructure.Timer;
using Hello_World.Infrastructure.ViewModels;
using Hello_World.Infrastructure.Views;
using Hello_World.MainWindow;
using Hello_World.Menu;
using Hello_World.Shop;

namespace Hello_World.GamePage
{
    public class GameViewModel : ViewModelBase, IDisplayableViewModel
    {
        private const string TextToPrint = "Hello World!";
        private readonly Game game;

        private readonly MainWindowViewModel mainWindowViewModel;

        private readonly IWindowDisplayer windowDisplayer;

        private int clicksPerSecond;

        public GameViewModel(Game game, MainWindowViewModel mainWindowViewModel, IWindowDisplayer windowDisplayer)
        {
            this.game = game;
            this.OnHelloWorldButtonClickCommand = new RelayCommand(this.OnHelloWorldButtonClick);
            this.OnMenuCommand = new RelayCommand(this.OnMenuButtonClick);
            this.OnShopButtonClickCommand = new RelayCommand(this.OnShopButtonClick);
            OneSecondTimer oneSecondTimer = new OneSecondTimer();
            oneSecondTimer.DispatcherTimer.Tick += this.OnTimerEnd;
            this.mainWindowViewModel = mainWindowViewModel;
            this.windowDisplayer = windowDisplayer;
        }

        public int HelloWorldPerSecond { get; set; }

        public RelayCommand OnHelloWorldButtonClickCommand { get; set; }

        public RelayCommand OnShopButtonClickCommand { get; set; }

        public RelayCommand OnMenuCommand { get; set; }

        public double Karma
        {
            get => this.game.Karma;
            private set => this.game.Karma = value;
        }

        public string TextBoxText { get; set; } = TextToPrint;

        //MVVM Event Handlers
        private void OnTimerEnd(object sender, EventArgs e)
        {
            int allHelloWorldPerSecond = this.CalculateAllAutomaticHelloWorldPerSecond();
            this.RefreshHelloWorldPerSecond();
            this.game.UpdateKarma();
            this.UpdateHelloWorldPerSecond(allHelloWorldPerSecond);
        }

        private void OnHelloWorldButtonClick()
        {
            this.PrintHelloWorld();
            this.UpdateKarma(1);
            this.UpdateClicksPerSecond(1);
        }

        private void OnMenuButtonClick()
        {
            this.mainWindowViewModel.MenuViewModel = new MenuViewModel(this.game, this.mainWindowViewModel);
            this.windowDisplayer.ShowDialogWindow(() => new MenuView(), this.mainWindowViewModel.MenuViewModel);
        }

        private void OnShopButtonClick()
        {
            ShopViewModel shopViewModel = this.mainWindowViewModel.ShopViewModel;

            if (shopViewModel == null || shopViewModel.IsWindowClosed)
            {
                if (shopViewModel == null)
                {
                    this.mainWindowViewModel.ShopViewModel = new ShopViewModel(this.game);
                    shopViewModel = this.mainWindowViewModel.ShopViewModel;
                }

                shopViewModel.IsWindowClosed = false;

                this.windowDisplayer.ShowWindow(() => new ShopView(), shopViewModel);
            }
            else
            {
                shopViewModel.RequestBringToFront();
            }
        }

        //Methods
        private void UpdateClicksPerSecond(int newClicks)
        {
            this.clicksPerSecond += newClicks;
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

            return this.game.HelloWorldProducers?.Sum(device => device.HelloWorldPerSecond) ??
                   allAutomaticHelloWorldsPerSecond;
        }
    }
}