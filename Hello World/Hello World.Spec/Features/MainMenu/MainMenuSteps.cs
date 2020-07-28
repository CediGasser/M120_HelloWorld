using FluentAssertions;
using Hello_World.GamePage;
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
                SpecFileDialogFactory specFileDialogFactory = new SpecFileDialogFactory();
                this.scenarioStorage.Store(new MainWindowViewModel(specFileDialogFactory));
            });
        }
    }    
    
    public class MainMenuWhen : WhenBase
    {
        private IScenarioStorage scenarioStorage;

        private MainWindowViewModel MainWindowViewModel => this.scenarioStorage.Get<MainWindowViewModel>();

        private MainMenuViewModel MainMenuViewModel => ((MainMenuViewModel)this.MainWindowViewModel.SelectedPageViewModel);

        private SpecFileDialogFactory SpecFileDialogFactory => (SpecFileDialogFactory)this.MainWindowViewModel.FileDialogFactory;

        public MainMenuWhen(IScenarioStorage scenarioStorage, bool useAnd) : base(scenarioStorage, useAnd)
        {
            this.scenarioStorage = scenarioStorage;
        }

        public void IClickOnNewGame()
        {
            this.CreateName().ToString().x(() =>
            {
                this.MainMenuViewModel.OnNewGameCommand.Execute();
            });
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
        private IScenarioStorage scenarioStorage;

        private MainWindowViewModel MainWindowViewModel => this.scenarioStorage.Get<MainWindowViewModel>();

        private GameViewModel GameViewModel => ((GameViewModel)this.MainWindowViewModel.SelectedPageViewModel);
        
        public MainMenuThen(IScenarioStorage scenarioStorage, bool useAnd) : base(scenarioStorage, useAnd)
        {
            this.scenarioStorage = scenarioStorage;
        }

        public void TheGameScreenShouldBeDisplayed()
        {
            this.CreateName().ToString().x(() =>
            {
                this.MainWindowViewModel.SelectedPageViewModel.Should().BeOfType<GameViewModel>();
            });
        }

        public void TheKarmaShouldBe(int karmaAmount)
        {
            this.CreateName().With(karmaAmount).x(() =>
            {
                this.GameViewModel.Karma.Should().Be(karmaAmount);
            });
        }
    }
}