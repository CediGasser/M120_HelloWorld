using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Hello_World.Core;
using Hello_World.GamePage;
using Hello_World.LoadAndSaveGame;
using Hello_World.MainWindow;

namespace Hello_World.Infrastructure
{
    public class GameViewModelFactory
    {

        public GameViewModel CreateGameViewModelWithLoadedGame(MainWindowViewModel mainWindowViewModel)
        {
            JsonFileManager jsonFileManager = new JsonFileManager(mainWindowViewModel.FileDialogFactory);
            Game loadedGame = jsonFileManager.LoadGame();
            return new GameViewModel(loadedGame, mainWindowViewModel, new WindowDisplayer());
        }

        public GameViewModel CreateGameViewModel(MainWindowViewModel mainWindowViewModel)
        {

            Game game = new Game(new DatetimeNowProvider());
            return new GameViewModel(game, mainWindowViewModel, new WindowDisplayer());
        }
    }
}
