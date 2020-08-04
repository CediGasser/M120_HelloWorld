using System.Collections.Generic;
using Hello_World.Infrastructure;
using Hello_World.Infrastructure.ViewModels;
using Hello_World.Infrastructure.Views;
using Hello_World.LoadAndSaveGame;
using Hello_World.MainMenuPage;
using Hello_World.Menu;
using Hello_World.Shop;

namespace Hello_World.MainWindow
{
    public class MainWindowViewModel : ViewModelBase, ICreaterViewModel
    {
        private readonly GameViewModelFactory gameViewModelFactory;

        private MenuViewModel menuViewModel;

        private ShopViewModel shopViewModel;

        public MainWindowViewModel(IFileDialogFactory fileDialogFactory, GameViewModelFactory gameViewModelFactory)
        {
            this.FileDialogFactory = fileDialogFactory;
            this.gameViewModelFactory = gameViewModelFactory;
            this.ChangeSelectedViewModelToMainMenu();
        }

        private List<IClosable> ClosableChildren { get; } = new List<IClosable>();

        public ShopViewModel ShopViewModel
        {
            get => this.shopViewModel;
            set
            {
                this.shopViewModel = value;
                this.AddToClosableChildren(value);
            }
        }

        public MenuViewModel MenuViewModel
        {
            get => this.menuViewModel;
            set
            {
                this.menuViewModel = value;
                this.AddToClosableChildren(value);
            }
        }


        public IFileDialogFactory FileDialogFactory { get; }

        public IDisplayableViewModel SelectedViewModel { get; set; }

        private void AddToClosableChildren(IClosable child)
        {
            if (!this.ClosableChildren.Contains(child)) this.ClosableChildren.Add(child);
        }

        public void CloseAllChildren()
        {
            foreach (IClosable child in this.ClosableChildren) child.RequestClose();
        }

        public void ChangeSelectedViewModelToNewGame()
        {
            this.SelectedViewModel = this.gameViewModelFactory.CreateGameViewModel(this);
        }

        public void ChangeSelectedViewModelToLoadedGame()
        {
            this.SelectedViewModel =
                this.gameViewModelFactory.CreateGameViewModelWithLoadedGame(this);
        }

        public void ChangeSelectedViewModelToMainMenu()
        {
            this.SelectedViewModel = new MainMenuViewModel(this);
        }
    }
}