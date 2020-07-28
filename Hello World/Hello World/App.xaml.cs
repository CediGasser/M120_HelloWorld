using System.Windows;
using Hello_World.MainWindow;
using Ninject;

namespace Hello_World
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            StandardKernel kernel = new StandardKernel(new Module());
            
            MainWindowViewModel mainWindowViewModel = kernel.Get<MainWindowViewModel>();
            MainWindowView mainWindow = new MainWindowView { DataContext = mainWindowViewModel };
            mainWindow.InitializeComponent();
            mainWindow.Show();
        }
    }
}