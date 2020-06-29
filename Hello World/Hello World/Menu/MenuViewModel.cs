using System;
using System.Collections.Generic;
using System.Text;
using Hello_World.Core;
using Hello_World.GamePage;
using Hello_World.Infrastructure.Commands;
using Hello_World.LoadAndSaveGame;
using Hello_World.MainMenuPage;
using Hello_World.MainWindow;

namespace Hello_World.Menu
{
    class MenuViewModel
    {
        public RelayCommand OnResumeCommand { get; set; }
        public RelayCommand OnSaveCommand { get; set; }
        public RelayCommand OnExitCommand { get; set; }

        private Game game;

        public MenuView View;

        public readonly MainWindowViewModel BaseViewModel;

        public MenuViewModel(Game game, MainWindowViewModel baseViewModel)
        {
            this.OnResumeCommand = new RelayCommand(OnResumeButtonClick);
            this.OnSaveCommand = new RelayCommand(OnSaveButtonClick);
            this.OnExitCommand = new RelayCommand(OnExitButtonClick);
            this.game = game;
            this.BaseViewModel = baseViewModel;
        }

        public void OnResumeButtonClick()
        {
            View.Close();
        }

        public void OnSaveButtonClick()
        {
            JsonFileManager jsonFileManager = new JsonFileManager();
            jsonFileManager.SaveGame(game);
            OnResumeButtonClick();
        }

        public void OnExitButtonClick()
        {
            BaseViewModel.SelectedPageView = new MainMenuView(){DataContext = new MainMenuViewModel(BaseViewModel)};
            OnResumeButtonClick();
        }
    }
}
