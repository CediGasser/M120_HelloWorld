using System;
using System.Windows;
using FakeItEasy;
using FluentAssertions;
using Hello_World.Core;
using Hello_World.GamePage;
using Hello_World.Infrastructure;
using Hello_World.Infrastructure.ViewModels;
using Hello_World.LoadAndSaveGame;
using Hello_World.MainMenuPage;
using Hello_World.MainWindow;
using Xbehave;
using xFlowPackage.BaseStepDefinitions;
using xFlowPackage.Context;

namespace Hello_World.Spec.Features.Shop
{
    public class ShopGiven : GivenBase
    {
        private readonly IScenarioStorage scenarioStorage;

        public ShopGiven(IScenarioStorage scenarioStorage, bool useAnd) : base(scenarioStorage, useAnd)
        {
            this.scenarioStorage = scenarioStorage;
        }

        public void IHaveStartedTheGameWithOneMillionKarma()
        {
            this.CreateName().WithoutParams().x(() =>
            {
                IErrorMessageDisplayer fakeErrorMessageDisplayer = A.Fake<IErrorMessageDisplayer>(o => o.Strict());

                DatetimeNowProvider datetimeNowProvider = new DatetimeNowProvider();
                Core.Game game = new Core.Game(datetimeNowProvider, fakeErrorMessageDisplayer);
                game.Karma = 1000000;
                FileDialogFactory fileDialogFactory = new FileDialogFactory();
                JsonFileManager jsonFileManager = new JsonFileManager(fileDialogFactory);
                MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(fileDialogFactory,
                    new GameViewModelFactory(jsonFileManager, fakeErrorMessageDisplayer, datetimeNowProvider));
                IWindowDisplayer fakeWindowDisplayer = A.Fake<IWindowDisplayer>();
                A.CallTo(() => fakeWindowDisplayer.ShowWindow(A<Func<Window>>.Ignored, A<IViewModel>.Ignored))
                    .DoesNothing();

                this.scenarioStorage.Store(mainWindowViewModel);
                this.scenarioStorage.Store(new GameViewModel(game, mainWindowViewModel, fakeWindowDisplayer));
            });
        }

    }

    public class ShopWhen : WhenBase
    {
        private readonly IScenarioStorage scenarioStorage;

        public ShopWhen(IScenarioStorage scenarioStorage, bool useAnd) : base(scenarioStorage, useAnd)
        {
            this.scenarioStorage = scenarioStorage;
        }

        private GameViewModel GameViewModel => this.scenarioStorage.Get<GameViewModel>();
        private MainWindowViewModel MainWindowViewModel => this.scenarioStorage.Get<MainWindowViewModel>();
        public void IClickOnShop()
        {
            this.CreateName().WithoutParams().x(() => { this.GameViewModel.OnShopButtonClickCommand.Execute(); });
        }

        public void IClickOnBuy(int i)
        {
            this.CreateName().WithoutParams().x(() =>
            {
                this.MainWindowViewModel.ShopViewModel.HelloWorldDeviceProducers[i].OnBuyButtonClickCommand.Execute();
            });
        }
    }

    public class ShopThen : ThenBase
    {
        private readonly IScenarioStorage scenarioStorage;

        private MainWindowViewModel MainWindowViewModel => this.scenarioStorage.Get<MainWindowViewModel>();

        public ShopThen(IScenarioStorage scenarioStorage, bool useAnd) : base(scenarioStorage, useAnd)
        {
            this.scenarioStorage = scenarioStorage;
        }
        public void DeviceCountShouldBeOne(int i)
        {
            this.CreateName().WithoutParams().x(() =>
            {
                this.MainWindowViewModel.ShopViewModel.HelloWorldDeviceProducers[i].Device.Count.Should().Be(1);
            });
        }
    }
}
