using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using Hello_World.Core;
using Hello_World.Infrastructure.Commands;
using Hello_World.Infrastructure.Timer;
using Hello_World.Infrastructure.ViewModels;
using Hello_World.Infrastructure.Views;
using Hello_World.Shop;
using Hello_World.MainMenuPage;
using Hello_World.MainWindow;
using Hello_World.Menu;
using PropertyChanged;

namespace Hello_World.GamePage
{
    public class GameViewModel : ViewModelBase, IDisplayablePageViewModel
    {
        private readonly Game game;

        private const string TextToPrint = "Hello World!";

        private int clicksPerSecond;

        private readonly MainWindowViewModel mainWindowViewModel;

        public GameViewModel(Game game, MainWindowViewModel mainWindowViewModel)
        {
            this.game = game;
            OnHelloWorldButtonClickCommand = new RelayCommand(OnHelloWorldButtonClick);
            OnMenuCommand = new RelayCommand(OnMenuButtonClick);
            OnShopButtonClickCommand = new RelayCommand(OnShopButtonClick);
            OneSecondTimer oneSecondTimer = new OneSecondTimer();
            oneSecondTimer.DispatcherTimer.Tick += OnTimerEnd;
            this.mainWindowViewModel = mainWindowViewModel;
        }

        public int HelloWorldPerSecond { get; set; }

        public RelayCommand OnHelloWorldButtonClickCommand { get; set; }

        public RelayCommand OnShopButtonClickCommand { get; set; }
        
        public RelayCommand OnMenuCommand { get; set; }

        public double Karma
        {
            get => game.Karma;
            set => game.Karma = value;
        }

        public string TextBoxText { get; set; } = TextToPrint;

        //MVVM Event Handlers
        private void OnTimerEnd(object sender, EventArgs e)
        {
            int allHelloWorldPerSecond = CalculateAllAutomaticHelloWorldPerSecond();
            RefreshHelloWorldPerSecond();
            game.UpdateKarma();
            UpdateHelloWorldPerSecond(allHelloWorldPerSecond);
        }

        private void OnHelloWorldButtonClick()
        {
            PrintHelloWorld();
            UpdateKarma(1);
            UpdateClicksPerSecond(1);
        }

        private void OnMenuButtonClick()
        {
            MenuViewModel menuViewmodel = new MenuViewModel(game, this.mainWindowViewModel);
            MenuView menuView = new MenuView() {DataContext = menuViewmodel};
            menuView.ShowDialog();
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
                
                ShopView shopView = new ShopView() {DataContext = shopViewModel};
                shopView.Show();
            }
            else
            {
                shopViewModel.RequestBringToFront();
            }
        }

        //Methods
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