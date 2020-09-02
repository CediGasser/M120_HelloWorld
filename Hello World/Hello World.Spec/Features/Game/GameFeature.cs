using Hello_World.Core;
using Hello_World.GamePage;
using Hello_World.MainWindow;
using Xbehave;
using xFlowPackage;
using xFlowPackage.Context;

namespace Hello_World.Spec.Features.Game
{
    // ReSharper disable ArrangeThisQualifier -- '_' should not be qualified with this for improved readability
    public class GameFeature
    {
        private readonly ScenarioContext<GameGiven, GameWhen, GameThen> _;

        public GameFeature()
        {
            _ =
                ScenarioContextBuilder
                    .Build<GameGiven, GameWhen, GameThen>()
                    .AlwaysUsingCommon<GameViewModel>()
                    .AlwaysUsingCommon<MainWindowViewModel>();
        }

        [Scenario]
        public void OnShopButtonClick_TheShopViewIsShown()
        {
            _.Given.IHaveStartedTheGame();
            _.When.IClickOnShop();
            _.Then.TheShopViewModelIsWindowClosedShouldBeFalse();
        }

        [Scenario]
        public void OnMenuButtonClick_TheMenuViewIsShown()
        {
            _.Given.IHaveStartedTheGame();
            _.When.IClickOnMenu();
            _.Then.TheMenuViewModelIsWindowClosedShouldBeFalse();
        }

        [Scenario]
        public void OnHelloWorldButtonClick_KarmaIsOneHigher()
        {
            _.Given.IHaveStartedTheGame();
            _.When.IClickOnHelloWorld();
            _.Then.TheKarmaShouldBe(new Core.Karma(0,1));
        }
    }
}