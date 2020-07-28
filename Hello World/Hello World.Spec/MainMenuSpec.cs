using System;
using System.Windows;
using FluentAssertions;
using Hello_World.GamePage;
using Hello_World.LoadAndSaveGame;
using Hello_World.MainMenuPage;
using Hello_World.MainWindow;
using Xbehave;
using Xunit;

namespace Hello_World.Spec
{
    public class MainMenuSpec
    {
        [Scenario]
        public void OnNewGame_TheGameViewModelIsShown()
        {
            MainWindowViewModel mainWindowViewModel = null;
            SpecFileDialogFactory specFileDialogFactory = new SpecFileDialogFactory();

            "Given I have started the game"
                .x(() => mainWindowViewModel = new MainWindowViewModel(specFileDialogFactory));

            "And I click on 'New Game'"
                .x(() => ((MainMenuViewModel) mainWindowViewModel.SelectedPageViewModel).OnNewGameCommand.Execute());

            "Then the Game screen should be displayed"
                .x(() => mainWindowViewModel.SelectedPageViewModel.Should().BeOfType<GameViewModel>());
        }

        [Scenario]
        public void OnLoadGame_TheGameViewModelIsShownAndTheGameWasLoadedCorrectly()
        {
            MainWindowViewModel mainWindowViewModel = null;
            SpecFileDialogFactory specFileDialogFactory = new SpecFileDialogFactory();

            "Given I have started the game"
                .x(() => mainWindowViewModel = new MainWindowViewModel(specFileDialogFactory));

            "And I click on 'Load Game' and select the file '..\\..\\..\\TestData\\mySavegame.json' to load"
                .x(() =>
                {
                    specFileDialogFactory.FileNameToLoad = "..\\..\\..\\TestData\\mySavegame.json";
                    //specOpenFileDialogFactory.FileNameToLoad = ".\\TestData\\mySavegame.json";
                    ((MainMenuViewModel) mainWindowViewModel.SelectedPageViewModel).OnLoadGameCommand.Execute();
                });

            "Then the Game screen should be displayed"
                .x(() => mainWindowViewModel.SelectedPageViewModel.Should().BeOfType<GameViewModel>());

            "And the Karma should be 450"
                .x(() => ((GameViewModel) mainWindowViewModel.SelectedPageViewModel).Karma.Should().Be(450));
        }

        private class SpecFileDialogFactory : IFileDialogFactory
        {
            public string FileNameToSave { get; set; }
            
            public string FileNameToLoad { get; set; }

            private class SpecFileDialog : IFileDialog
            {
                public string FileName { get; set; }

                public bool ShowDialog() => true;
            }

            public IFileDialog CreateSaveFileDialog(string filter, string initialDirectory)
            {
                return new SpecFileDialog() { FileName = this.FileNameToSave };
            }

            public IFileDialog CreateOpenFileDialog(string filter, string initialDirectory)
            {
                return new SpecFileDialog() {FileName = this.FileNameToLoad};
            }
        }
    }
}