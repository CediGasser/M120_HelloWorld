using System;
using System.Windows;
using Hello_World.Core;
using Hello_World.GamePage;
using Hello_World.Infrastructure.Commands;
using Hello_World.MainWindow;
using Hello_World.Infrastructure.ViewModels;
using Hello_World.Infrastructure.Views;
using Hello_World.LoadAndSaveGame;

namespace Hello_World.MainMenuPage
{
    public class MainMenuViewModel : ViewModelBase, IDisplayablePageViewModel
    {
        public RelayCommand OnNewGameCommand { get; set; }

        public RelayCommand OnLoadGameCommand { get; set; }

        public RelayCommand OnQuitCommand { get; set; }

        private readonly MainWindowViewModel mainWindowViewModel;
        private readonly WindowDisplayer windowDisplayer;

        public MainMenuViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.OnNewGameCommand = new RelayCommand(OnNewGameButtonClick);
            this.OnLoadGameCommand = new RelayCommand(OnLoadGameButtonClick);
            this.OnQuitCommand = new RelayCommand(OnQuitButtonClick);
            this.windowDisplayer = new WindowDisplayer();
            this.mainWindowViewModel = mainWindowViewModel;
        }

        public void OnNewGameButtonClick()
        {
            Game game = new Game(new DatetimeNowProvider());
            this.mainWindowViewModel.SelectedPageViewModel = new GameViewModel(game, this.mainWindowViewModel, this.windowDisplayer);
        }

        public void OnLoadGameButtonClick()
        {
            JsonFileManager jsonFileManager = new JsonFileManager(mainWindowViewModel.FileDialogFactory);
            try
            {
                Game game = jsonFileManager.LoadGame();
                this.mainWindowViewModel.SelectedPageViewModel = new GameViewModel(game, this.mainWindowViewModel, this.windowDisplayer);
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
