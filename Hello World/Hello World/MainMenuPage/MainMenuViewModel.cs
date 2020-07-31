using System;
using System.Windows;
using Hello_World.Core;
using Hello_World.GamePage;
using Hello_World.Infrastructure;
using Hello_World.Infrastructure.Commands;
using Hello_World.MainWindow;
using Hello_World.Infrastructure.ViewModels;
using Hello_World.Infrastructure.Views;
using Hello_World.LoadAndSaveGame;

namespace Hello_World.MainMenuPage
{
    public class MainMenuViewModel : ViewModelBase, IDisplayableViewModel
    {
        public RelayCommand OnNewGameCommand { get; set; }

        public RelayCommand OnLoadGameCommand { get; set; }

        public RelayCommand OnQuitCommand { get; set; }

        private readonly MainWindowViewModel mainWindowViewModel;


        public MainMenuViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.OnNewGameCommand = new RelayCommand(OnNewGameButtonClick);
            this.OnLoadGameCommand = new RelayCommand(OnLoadGameButtonClick);
            this.OnQuitCommand = new RelayCommand(OnQuitButtonClick);
            this.mainWindowViewModel = mainWindowViewModel;
        }

        private void OnNewGameButtonClick()
        {
            this.mainWindowViewModel.ChangeSelectedViewModelToNewGame();
        }

        private void OnLoadGameButtonClick()
        {
            try
            {
                this.mainWindowViewModel.ChangeSelectedViewModelToLoadedGame();
            }
            catch (NoPathSelectedException)
            {
                MessageBox.Show("Not a Valid File!", "Warning");
            }
        }

        public void OnQuitButtonClick()
        {
            Environment.Exit(0);
        }
    }
}
