using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Documents;
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
using System.Collections.ObjectModel;

namespace Hello_World.GamePage
{
    public class GameViewModel : ViewModelBase, IDisplayablePageViewModel
    {
        private readonly Game game;

        private const string TextToPrint = "Hello World!";

        private int clicksPerSecond;

        private readonly MainWindowViewModel mainWindowViewModel;

        private readonly WindowDisplayer windowDisplayer;

        public GameViewModel(Game game, MainWindowViewModel mainWindowViewModel, WindowDisplayer windowDisplayer)
        {
            this.game = game;
            OnHelloWorldButtonClickCommand = new RelayCommand(OnHelloWorldButtonClick);
            OnMenuCommand = new RelayCommand(OnMenuButtonClick);
            OnShopButtonClickCommand = new RelayCommand(OnShopButtonClick);
            OneSecondTimer oneSecondTimer = new OneSecondTimer();
            oneSecondTimer.DispatcherTimer.Tick += OnTimerEnd;
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
            MenuViewModel menuViewmodel = new MenuViewModel(this.game, this.mainWindowViewModel);
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
            var allAutomaticHelloWorldsPerSecond = 0;

            if (this.game.HelloWorldProducers == null) return allAutomaticHelloWorldsPerSecond;
            return this.game.HelloWorldProducers.Sum(device => device.HelloWorldPerSecond);
        }
    }

    public class WindowDisplayer
    {
        public void ShowWindow<T>(Func<T> windowCreationFunction, IViewModel dataContext) where T : Window
        {
            T window = windowCreationFunction.Invoke();

            window.DataContext = dataContext;
            window.Show();
        }
    }
}