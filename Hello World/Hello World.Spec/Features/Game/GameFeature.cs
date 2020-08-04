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
        private ScenarioContext<GameGiven, GameWhen, GameThen> _;

        public GameFeature()
        {
            this._ =
                ScenarioContextBuilder
                    .Build<GameGiven, GameWhen, GameThen>()
                    .AlwaysUsingCommon<GameViewModel>()
                    .AlwaysUsingCommon<MainWindowViewModel>();
        }

        [Scenario]
        public void OnShopButtonClick_TheShopViewIsShown()
        {
            this._.Given.IHaveStartedTheGame();
            this._.When.IClickOnShop();
            this._.Then.TheShopViewModelIsWindowClosedShouldBeFalse();
        }

        [Scenario]
        public void OnHelloWorldButtonClick_KarmaIsOneHigher()
        {
            this._.Given.IHaveStartedTheGame();
            this._.When.IClickOnHelloWorld();
           this._.Then.TheKarmaShouldBe(1);
        }
    }
}