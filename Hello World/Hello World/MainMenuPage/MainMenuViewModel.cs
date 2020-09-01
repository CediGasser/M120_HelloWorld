using System;
using System.Windows;
using Hello_World.Infrastructure.Commands;
using Hello_World.Infrastructure.ViewModels;
using Hello_World.Infrastructure.Views;
using Hello_World.LoadAndSaveGame;
using Hello_World.MainWindow;

namespace Hello_World.MainMenuPage
{
    public class MainMenuViewModel : ViewModelBase, IDisplayableViewModel
    {
        private readonly MainWindowViewModel mainWindowViewModel;


        public MainMenuViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.OnNewGameCommand = new RelayCommand(this.OnNewGameButtonClick);
            this.OnLoadGameCommand = new RelayCommand(this.OnLoadGameButtonClick);
            this.OnQuitCommand = new RelayCommand(this.OnQuitButtonClick);
            this.mainWindowViewModel = mainWindowViewModel;
        }

        public RelayCommand OnNewGameCommand { get; set; }

        public RelayCommand OnLoadGameCommand { get; set; }

        public RelayCommand OnQuitCommand { get; set; }

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