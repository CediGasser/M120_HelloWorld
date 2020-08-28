using Hello_World.GamePage;
using Hello_World.MainWindow;
using Hello_World.Shop;
using Xbehave;
using xFlowPackage;
using xFlowPackage.Context;

namespace Hello_World.Spec.Features.Shop
{ 
    // ReSharper disable ArrangeThisQualifier -- '_' should not be qualified with this for improved readability
    public class ShopFeature
    {
        private ScenarioContext<ShopGiven, ShopWhen, ShopThen> _;

        public ShopFeature()
        {
            _ = ScenarioContextBuilder.Build<ShopGiven, ShopWhen, ShopThen>()
                .AlwaysUsingCommon<ShopViewModel>()
                .AlwaysUsingCommon<GameViewModel>()
                .AlwaysUsingCommon<MainWindowViewModel>(); 
        }

        [Scenario]
        public void OnBuyWithEnoughKarma_BuyTheDevice()
        {
            _.Given.IHaveStartedTheGameWithOneMillionKarma();
            _.When.IClickOnShop();
            _.When.IClickOnBuy(1);
            _.Then.DeviceCountShouldBeOne(1);
            _.When.IClickOnBuy(2);
            _.Then.DeviceCountShouldBeOne(2);
            _.When.IClickOnBuy(0);
            _.Then.DeviceCountShouldBeOne(0);
            _.When.IClickOnBuy(3);
            _.Then.DeviceCountShouldBeOne(3);
        }
    }
}
