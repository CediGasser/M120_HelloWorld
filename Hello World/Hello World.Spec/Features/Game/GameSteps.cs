using System;
using System.Windows;
using FakeItEasy;
using FluentAssertions;
using Hello_World.Core;
using Hello_World.GamePage;
using Hello_World.Infrastructure;
using Hello_World.Infrastructure.ViewModels;
using Hello_World.LoadAndSaveGame;
using Hello_World.MainWindow;
using Xbehave;
using xFlowPackage.BaseStepDefinitions;
using xFlowPackage.Context;

namespace Hello_World.Spec.Features.Game
{
    public class GameGiven : GivenBase
    {
        private readonly IScenarioStorage scenarioStorage;

        public GameGiven(IScenarioStorage scenarioStorage, bool useAnd) : base(scenarioStorage, useAnd)
        {
            this.scenarioStorage = scenarioStorage;
        }

        public void IHaveStartedTheGame()
        {
            this.CreateName().WithoutParams().x(() =>
            {
                IErrorMessageDisplayer fakeErrorMessageDisplayer = A.Fake<IErrorMessageDisplayer>(o => o.Strict());

                DatetimeNowProvider datetimeNowProvider = new DatetimeNowProvider();
                Core.Game game = new Core.Game(datetimeNowProvider, fakeErrorMessageDisplayer);
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

    public class GameWhen : WhenBase
    {
        private readonly IScenarioStorage scenarioStorage;


        public GameWhen(IScenarioStorage scenarioStorage, bool useAnd) : base(scenarioStorage, useAnd)
        {
            this.scenarioStorage = scenarioStorage;
        }

        private GameViewModel GameViewModel => this.scenarioStorage.Get<GameViewModel>();

        public void IClickOnHelloWorld()
        {
            this.CreateName().WithoutParams().x(() => { this.GameViewModel.OnHelloWorldButtonClickCommand.Execute(); });
        }

        public void IClickOnShop()
        {
            this.CreateName().WithoutParams().x(() => { this.GameViewModel.OnShopButtonClickCommand.Execute(); });
        }

        public void IClickOnMenu()
        {
            this.CreateName().WithoutParams().x(() => { this.GameViewModel.OnMenuClickCommand.Execute(); });
        }
    }

    public class GameThen : ThenBase
    {
        private readonly IScenarioStorage scenarioStorage;

        public GameThen(IScenarioStorage scenarioStorage, bool useAnd) : base(scenarioStorage, useAnd)
        {
            this.scenarioStorage = scenarioStorage;
        }

        private GameViewModel GameViewModel => this.scenarioStorage.Get<GameViewModel>();
        private MainWindowViewModel MainWindowViewModel => this.scenarioStorage.Get<MainWindowViewModel>();

        public void TheKarmaShouldBe(Karma karmaAmount)
        {
            this.CreateName().With(karmaAmount.Value).x(() => { this.GameViewModel.Karma.Value.Should().BeEquivalentTo(karmaAmount.Value); });
        }

        public void TheShopViewModelIsWindowClosedShouldBeFalse()
        {
            this.CreateName().WithoutParams().x(() => { this.MainWindowViewModel.ShopViewModel.IsWindowClosed.Should().BeFalse(); });
        }

        public void TheMenuViewModelIsWindowClosedShouldBeFalse()
        {
            this.CreateName().WithoutParams().x(() => { this.MainWindowViewModel.MenuViewModel.IsWindowClosed.Should().BeFalse(); });
        }
    }
}