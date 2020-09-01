using System;
using Hello_World.Core;
using Hello_World.Infrastructure;
using Hello_World.Infrastructure.Commands;
using Hello_World.Infrastructure.ViewModels;
using Hello_World.LoadAndSaveGame;
using Hello_World.MainWindow;

namespace Hello_World.Menu
{
    public class MenuViewModel : ViewModelBase, IClosable
    {
        private readonly Game game;

        public readonly MainWindowViewModel MainWindowViewModel;

        public MenuViewModel(Game game, MainWindowViewModel mainWindowViewModel)
        {
            this.OnResumeCommand = new RelayCommand(this.OnResumeButtonClick);
            this.OnSaveCommand = new RelayCommand(this.OnSaveButtonClick);
            this.OnExitCommand = new RelayCommand(this.OnExitButtonClick);
            this.game = game;
            this.MainWindowViewModel = mainWindowViewModel;
        }

        public bool IsWindowClosed { get; internal set; } = true;

        public RelayCommand OnResumeCommand { get; set; }
        public RelayCommand OnSaveCommand { get; set; }
        public RelayCommand OnExitCommand { get; set; }

        public void RequestClose()
        {
            this.OnCloseRequested();
        }

        public event EventHandler CloseRequested;

        public void OnResumeButtonClick()
        {
            this.OnCloseRequested();
        }

        public void OnSaveButtonClick()
        {
            JsonFileManager jsonFileManager = new JsonFileManager(this.MainWindowViewModel.FileDialogFactory);
            jsonFileManager.SaveGame(this.game);
            this.OnCloseRequested();
        }

        public void OnExitButtonClick()
        {
            this.MainWindowViewModel.ChangeSelectedViewModelToMainMenu();
            this.MainWindowViewModel.CloseAllChildren();
        }

        protected virtual void OnCloseRequested()
        {
            this.CloseRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}