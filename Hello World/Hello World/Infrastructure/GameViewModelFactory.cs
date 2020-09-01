using Hello_World.Core;
using Hello_World.GamePage;
using Hello_World.LoadAndSaveGame;
using Hello_World.MainWindow;

namespace Hello_World.Infrastructure
{
    public class GameViewModelFactory
    {
        private readonly DatetimeNowProvider datetimeNowProvider;
        private readonly IErrorMessageDisplayer errorMessageDisplayer;
        private readonly JsonFileManager jsonFileManager;

        public GameViewModelFactory(JsonFileManager jsonFileManager, IErrorMessageDisplayer errorMessageDisplayer,
            DatetimeNowProvider datetimeNowProvider)
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