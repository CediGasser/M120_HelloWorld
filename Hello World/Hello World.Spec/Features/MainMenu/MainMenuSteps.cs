using FakeItEasy;
using FluentAssertions;
using Hello_World.Core;
using Hello_World.GamePage;
using Hello_World.Infrastructure;
using Hello_World.LoadAndSaveGame;
using Hello_World.MainMenuPage;
using Hello_World.MainWindow;
using Xbehave;
using xFlowPackage.BaseStepDefinitions;
using xFlowPackage.Context;

namespace Hello_World.Spec.Features.MainMenu
{
    public class MainMenuGiven : GivenBase
    {
        private readonly IScenarioStorage scenarioStorage;

        public MainMenuGiven(IScenarioStorage scenarioStorage, bool useAnd) : base(scenarioStorage, useAnd)
        {
            this.scenarioStorage = scenarioStorage;
        }

        public void IHaveStartedTheGame()
        {
            this.CreateName().ToString().x(() =>
            {
                IErrorMessageDisplayer fakeErrorMessageDisplayer = A.Fake<IErrorMessageDisplayer>(o => o.Strict());
                SpecFileDialogFactory specFileDialogFactory = new SpecFileDialogFactory();
                this.scenarioStorage.Store(new MainWindowViewModel(specFileDialogFactory,
                    new GameViewModelFactory(new JsonFileManager(specFileDialogFactory), fakeErrorMessageDisplayer, new DatetimeNowProvider())));
            });
        }
    }

    public class MainMenuWhen : WhenBase
    {
        private readonly IScenarioStorage scenarioStorage;

        public MainMenuWhen(IScenarioStorage scenarioStorage, bool useAnd) : base(scenarioStorage, useAnd)
        {
            this.scenarioStorage = scenarioStorage;
        }

        private MainWindowViewModel MainWindowViewModel => this.scenarioStorage.Get<MainWindowViewModel>();

        private MainMenuViewModel MainMenuViewModel => (MainMenuViewModel) this.MainWindowViewModel.SelectedViewModel;

        private SpecFileDialogFactory SpecFileDialogFactory => (SpecFileDialogFactory) this.MainWindowViewModel.FileDialogFactory;

        public void IClickOnNewGame()
        {
            this.CreateName().WithoutParams().x(() => { this.MainMenuViewModel.OnNewGameCommand.Execute(); });
        }

        public void IClickOnLoadGameAndSelectTheFileP1ToLoad(string fileToLoad)
        {
            this.CreateName().With($"'{fileToLoad}'").x(() =>
            {
                this.SpecFileDialogFactory.FileNameToLoad = fileToLoad;
                this.MainMenuViewModel.OnLoadGameCommand.Execute();
            });
        }
    }

    public class MainMenuThen : ThenBase
    {
        private readonly IScenarioStorage scenarioStorage;

        public MainMenuThen(IScenarioStorage scenarioStorage, bool useAnd) : base(scenarioStorage, useAnd)
        {
            this.scenarioStorage = scenarioStorage;
        }

        private MainWindowViewModel MainWindowViewModel => this.scenarioStorage.Get<MainWindowViewModel>();

        private GameViewModel GameViewModel => (GameViewModel) this.MainWindowViewModel.SelectedViewModel;

        public void TheGameScreenShouldBeDisplayed()
        {
            this.CreateName().WithoutParams().x(() => { this.MainWindowViewModel.SelectedViewModel.Should().BeOfType<GameViewModel>(); });
        }

        public void TheKarmaShouldBe(int karmaAmount)
        {
            this.CreateName().With(karmaAmount).x(() => { this.GameViewModel.Karma.Should().Be(karmaAmount); });
        }
    }
}