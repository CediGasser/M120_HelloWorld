using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Hello_World.Core;
using Hello_World.GamePage;
using Hello_World.MainWindow;

namespace Hello_World
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            MainWindowView mainWindow = new MainWindowView(){DataContext = new MainWindowViewModel(new GameView(){DataContext = new GameViewModel(new Game(23))})};
            mainWindow.InitializeComponent();
            mainWindow.Show();
        }
    }
}
