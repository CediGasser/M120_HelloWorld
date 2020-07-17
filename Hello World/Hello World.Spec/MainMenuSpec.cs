using System;
using FluentAssertions;
using Hello_World.GamePage;
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
            
            "Given I have started the game"
                .x(() => mainWindowViewModel = new MainWindowViewModel());
            
            "And I click on 'New Game'"
                .x(()=> ((MainMenuViewModel) mainWindowViewModel.SelectedPageViewModel).OnNewGameCommand.Execute());

            "Then the Game screen should be displayed"
                .x(() => mainWindowViewModel.SelectedPageViewModel.Should().BeOfType<GameViewModel>());
        }          
        
        [Scenario]
        public void OnNewGame_TheGameViewModelIsShown()
        {
            MainWindowViewModel mainWindowViewModel = null;
            
            "Given I have started the game"
                .x(() => mainWindowViewModel = new MainWindowViewModel());
            
            "And I click on 'Load Game'"
                .x(()=> ((MainMenuViewModel) mainWindowViewModel.SelectedPageViewModel).OnLoadGameCommand.Execute());

            "Then the Game screen should be displayed"
                .x(() => mainWindowViewModel.SelectedPageViewModel.Should().BeOfType<GameViewModel>());
        }        
        
    }
}