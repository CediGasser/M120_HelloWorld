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
        private readonly JsonFileManager jsonFileManager;
        private readonly IErrorMessageDisplayer errorMessageDisplayer;
        private readonly DatetimeNowProvider datetimeNowProvider;

        public GameViewModelFactory(JsonFileManager jsonFileManager, IErrorMessageDisplayer errorMessageDisplayer, DatetimeNowProvider datetimeNowProvider)
        {
            this.jsonFileManager = jsonFileManager;
            this.errorMessageDisplayer = errorMessageDisplayer;
            this.datetimeNowProvider = datetimeNowProvider;
        }

        public GameViewModel CreateGameViewModelWithLoadedGame(MainWindowViewModel mainWindowViewModel)
        {
            Game loadedGame = this.jsonFileManager.LoadGame();
            return new GameViewModel(loadedGame, mainWindowViewModel, new WindowDisplayer());
        }

        public GameViewModel CreateGameViewModel(MainWindowViewModel mainWindowViewModel)
        {
            Game game = new Game(this.datetimeNowProvider, this.errorMessageDisplayer);
            return new GameViewModel(game, mainWindowViewModel, new WindowDisplayer());
        }
    }
}
