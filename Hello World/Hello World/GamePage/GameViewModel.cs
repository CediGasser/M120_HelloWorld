using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using Hello_World.Core;
using Hello_World.Infrastructure.Commands;
using Hello_World.Infrastructure.Timer;
using Hello_World.Infrastructure.ViewModels;
using Hello_World.Shop;
using Hello_World.MainMenuPage;
using Hello_World.MainWindow;
using Hello_World.Menu;
using PropertyChanged;

namespace Hello_World.GamePage
{
    internal class GameViewModel : ViewModelBase
    {
        private readonly Game game;
        private ShopView shopView;

        private const string TextToPrint = "Hello World!";

        private int clicksPerSecond;
        private readonly MainWindowViewModel baseViewModel;

        private void gamePropertyChange(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Karma")
            {
                Karma = game.Karma;
            }
        }

        public GameViewModel(Game game, MainWindowViewModel baseViewModel)
        {
            this.game = game;
            this.game.PropertyChanged += gamePropertyChange;
            OnHelloWorldButtonClickCommand = new RelayCommand(OnHelloWorldButtonClick);
            OnMenuCommand = new RelayCommand(OnMenuButtonClick);
            OnShopButtonClickCommand = new RelayCommand(OnShopButtonClick);
            OneSecondTimer oneSecondTimer = new OneSecondTimer();
            oneSecondTimer.DispatcherTimer.Tick += OnTimerEnd;
            this.baseViewModel = baseViewModel;
            this.shopView = new ShopView() {DataContext = new ShopViewModel(this.game)};
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
            this.shopView.Close();
            MenuView menuView = new MenuView() { DataContext = new MenuViewModel(game, baseViewModel) };
            ((MenuViewModel)menuView.DataContext).View = menuView;
            menuView.ShowDialog();
        }

        private void OnShopButtonClick()
        {
            this.shopView = new ShopView() { DataContext = new ShopViewModel(this.game) };
            this.shopView.Show();
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