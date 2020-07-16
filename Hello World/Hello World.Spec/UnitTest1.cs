using System;
using Hello_World.MainWindow;
using Xbehave;
using Xunit;

namespace Hello_World.Spec
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            MainWindowViewModel mainWindowViewModel;

            "Given I have started the game"
                .x(() => mainWindowViewModel = new MainWindowViewModel());

            //mainWindowViewModel.SelectedPageViewModel
        }
    }
}