using Hello_World.MainWindow;
using Xbehave;
using xFlowPackage;
using xFlowPackage.Context;

namespace Hello_World.Spec.Features.MainMenu
{
    // ReSharper disable ArrangeThisQualifier -- '_' should not be qualified with this for improved readability
    public class MainMenuFeature
    {
        private ScenarioContext<MainMenuGiven, MainMenuWhen, MainMenuThen> _;

        public MainMenuFeature()
        {
            this._ =
                ScenarioContextBuilder
                    .Build<MainMenuGiven, MainMenuWhen, MainMenuThen>()
                    .AlwaysUsingCommon<MainWindowViewModel>();
        }

        [Scenario]
        public void OnNewGame_TheGameViewModelIsShown()
        {
            this._.Given.IHaveStartedTheGame();
            this._.When.IClickOnNewGame();
            this._.Then.TheGameScreenShouldBeDisplayed();
        }

        [Scenario]
        public void OnLoadGame_TheGameViewModelIsShownAndTheGameWasLoadedCorrectly()
        {
            this._.Given.IHaveStartedTheGame();
            this._.When.IClickOnLoadGameAndSelectTheFileP1ToLoad(@"..\..\..\TestData\mySavegame.json");
            this._.Then.TheGameScreenShouldBeDisplayed();
            this._.Then.TheKarmaShouldBe(450);
        }
    }
}