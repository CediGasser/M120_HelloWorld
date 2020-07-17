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

        private readonly Game game;

        public readonly MainWindowViewModel MainWindowViewModel;

        public event EventHandler CloseRequested;

        public MenuViewModel(Game game, MainWindowViewModel mainWindowViewModel)
        {
            this.OnResumeCommand = new RelayCommand(OnResumeButtonClick);
            this.OnSaveCommand = new RelayCommand(OnSaveButtonClick);
            this.OnExitCommand = new RelayCommand(OnExitButtonClick);
            this.game = game;
            this.MainWindowViewModel = mainWindowViewModel;
        }

        public void OnResumeButtonClick()
        {
            this.OnCloseRequested();
        }

        public void OnSaveButtonClick()
        {
            JsonFileManager jsonFileManager = new JsonFileManager(this.MainWindowViewModel.FileDialogFactory);
            jsonFileManager.SaveGame(game);
            this.OnCloseRequested();
        }

        public void OnExitButtonClick()
        {
            this.MainWindowViewModel.SelectedPageViewModel = new MainMenuViewModel(this.MainWindowViewModel);
            this.MainWindowViewModel.ShopViewModel.RequestClose();
            this.OnCloseRequested();
        }

        protected virtual void OnCloseRequested()
        {
            this.CloseRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
