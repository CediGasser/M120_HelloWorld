namespace Bibliothek
{
    using System.Windows;

    using Bibliothek.Core;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(new Book("Fairy Hotter", "Science", 651))
            };

            mainWindow.Show();
        }
    }
}
