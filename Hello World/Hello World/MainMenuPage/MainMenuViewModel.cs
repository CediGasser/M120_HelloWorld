using System;
using System.Collections.Generic;
using System.Text;
using Hello_World.Core;
using Hello_World.GamePage;
using Hello_World.Infrastructure.Commands;
using Hello_World.MainWindow;
using Hello_World.Infrastructure.ViewModels;

namespace Hello_World.MainMenuPage
{
    class MainMenuViewModel : ViewModelBase
    {
        public RelayCommand OnNewGameCommand { get; set; }
        public RelayCommand OnLoadGameCommand { get; set; }
        public RelayCommand OnQuitCommand { get; set; }

        public MainWindowViewModel baseViewModel;

        public MainMenuViewModel(MainWindowViewModel baseViewModel)
        {
            this.OnNewGameCommand = new RelayCommand(OnNewGameButtonClick);
            this.OnLoadGameCommand = new RelayCommand(OnLoadGameButtonClick);
            this.OnQuitCommand = new RelayCommand(OnQuitButtonClick);
            this.baseViewModel = baseViewModel;
        }

        public void OnNewGameButtonClick()
        {
            Game game = new Game(23);
            this.baseViewModel.SelectedPageView = new GameView() {DataContext = new GameViewModel(game)};
        }

        public void OnLoadGameButtonClick()
        {

        }

        public void OnQuitButtonClick()
        {
            Environment.Exit(0);
        }
    }
}
