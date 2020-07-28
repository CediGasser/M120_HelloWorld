using Hello_World.Infrastructure.ViewModels;
using Hello_World.Infrastructure.Views;
using Hello_World.LoadAndSaveGame;
using Hello_World.MainMenuPage;
using Hello_World.Shop;

namespace Hello_World.MainWindow
{
    public class MainWindowViewModel : ViewModelBase, ICreaterViewModel
    {
        public MainWindowViewModel(IFileDialogFactory fileDialogFactory)
        {
            this.FileDialogFactory = fileDialogFactory;
            this.SelectedPageViewModel = new MainMenuViewModel(this);
        }

        public ShopViewModel ShopViewModel { get; set; }

        public IFileDialogFactory FileDialogFactory { get; }

        public IDisplayablePageViewModel SelectedPageViewModel { get; set; }
    }
}