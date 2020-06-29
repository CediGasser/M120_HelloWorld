using System;
using Hello_World.Core;
using Hello_World.Infrastructure.Commands;
using Hello_World.Infrastructure.Timer;
using Hello_World.Infrastructure.ViewModels;
using Hello_World.MainMenuPage;
using Hello_World.MainWindow;
using Hello_World.Menu;

namespace Hello_World.GamePage
{
    internal class GameViewModel : ViewModelBase
    {
        private readonly Game game;
        private const string TextToPrint = "Hello World";

        private int clicksPerSecond;
        private readonly MainWindowViewModel baseViewModel;

        public GameViewModel(Game game, MainWindowViewModel baseViewModel)
        {
            this.game = game;
            OnHelloWorldButtonClickCommand = new RelayCommand(OnHelloWorldButtonClick);
            OnMenuCommand = new RelayCommand(OnMenuButtonClick);
            OneSecondTimer oneSecondTimer = new OneSecondTimer();
            oneSecondTimer.dispatcherTimer.Tick += OnTimerEnd;
            this.baseViewModel = baseViewModel;
        }

        public int HelloWorldPerSecond { get; set; }

        public RelayCommand OnHelloWorldButtonClickCommand { get; set; }

        public RelayCommand OnMenuCommand { get; set; }

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

        private void OnMenuButtonClick()
        {
            MenuView menuView = new MenuView() {DataContext = new MenuViewModel(game, baseViewModel)};
            ((MenuViewModel) menuView.DataContext).view = menuView;
            menuView.ShowDialog();
        }
    }
}