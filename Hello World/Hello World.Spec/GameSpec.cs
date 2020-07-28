using System;
using System.Windows;
using FluentAssertions;
using Hello_World.Core;
using Hello_World.GamePage;
using Hello_World.LoadAndSaveGame;
using Hello_World.MainMenuPage;
using Hello_World.MainWindow;
using Xbehave;
using Xunit;

namespace Hello_World.Spec
{
    public class GameSpec
    {
        
        [Scenario]
        public void OnHelloWorldButtonClick_KarmaIsOneHigher()
        {
            MainWindowViewModel mainWindowViewModel = null;

            "Given I have started the game"
                .x(() => mainWindowViewModel = new MainWindowViewModel(new FileDialogFactory()));

            "And I click on 'New Game'"
                .x(() => ((MainMenuViewModel) mainWindowViewModel.SelectedPageViewModel).OnNewGameCommand.Execute());

            "Then I click on 'Hello World'"
                .x((() => ((GameViewModel)mainWindowViewModel.SelectedPageViewModel).OnHelloWorldButtonClickCommand.Execute()));

            "Then Karma should be '1'"
                .x(() => ((GameViewModel)mainWindowViewModel.SelectedPageViewModel).Karma.Should().Be(1));
        }

        [Scenario]
        public void OnShopButtonClick_TheShopViewIsShown()
        {
            MainWindowViewModel mainWindowViewModel = null;

            "Given I have started the game"
                .x(() => mainWindowViewModel = new MainWindowViewModel(new FileDialogFactory()));

            "And I click on 'New Game'"
                .x(() => ((MainMenuViewModel)mainWindowViewModel.SelectedPageViewModel).OnNewGameCommand.Execute());

            "Then I click on 'Shop'"
                .x((() => ((GameViewModel)mainWindowViewModel.SelectedPageViewModel).OnShopButtonClickCommand.Execute()));

            "The Shop should be shown"
                .x(() => mainWindowViewModel.ShopViewModel.IsWindowClosed.Should().Be(false));
        }

    }
}