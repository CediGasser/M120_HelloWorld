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
            _ =
                ScenarioContextBuilder
                    .Build<MainMenuGiven, MainMenuWhen, MainMenuThen>()
                    .AlwaysUsingCommon<MainWindowViewModel>();
        }

        [Scenario]
        public void OnNewGame_TheGameViewModelIsShown()
        {
            _.Given.IHaveStartedTheGame();
            _.When.IClickOnNewGame();
            _.Then.TheGameScreenShouldBeDisplayed();
        }

        [Scenario]
        public void OnLoadGame_TheGameViewModelIsShownAndTheGameWasLoadedCorrectly()
        {
            _.Given.IHaveStartedTheGame();
            _.When.IClickOnLoadGameAndSelectTheFileP1ToLoad(@"..\..\..\TestData\mySavegame.json");
            _.Then.TheGameScreenShouldBeDisplayed();
            _.Then.TheKarmaShouldBe(450);
        }
    }
}