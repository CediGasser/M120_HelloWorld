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
        public MainWindowViewModel(IFileDialogFactory fileDialogFactory, GameViewModelFactory gameViewModelFactory, JsonFileManager jsonFileManager)
        {
            this.FileDialogFactory = fileDialogFactory;
            this.gameViewModelFactory = gameViewModelFactory;
            this.jsonFileManager = jsonFileManager;
            this.ChangeSelectedViewModelToMainMenu();
        }

        private readonly GameViewModelFactory gameViewModelFactory;

        private ShopViewModel shopViewModel;

        private MenuViewModel menuViewModel;
        private readonly JsonFileManager jsonFileManager;

        private List<IClosable>ClosableChildren { get; set; } = new List<IClosable>();

        public ShopViewModel ShopViewModel
        {
            get => this.shopViewModel;
            set { this.shopViewModel = value; AddToClosableChildren(value); }
        }

        public MenuViewModel MenuViewModel
        {
            get => this.menuViewModel;
            set { this.menuViewModel = value; AddToClosableChildren(value); }
        }


        public IFileDialogFactory FileDialogFactory { get; }

        public IDisplayableViewModel SelectedViewModel { get; set; }

        private void AddToClosableChildren(IClosable child)
        {
            if (!this.ClosableChildren.Contains(child))
            {
                this.ClosableChildren.Add(child);
            }
        }

        public void CloseAllChildren()
        {
            foreach (IClosable child in ClosableChildren)
            {
                child.RequestClose();
            }
        }
        public void ChangeSelectedViewModelToNewGame()
        {
            this.SelectedViewModel = this.gameViewModelFactory.CreateGameViewModel(this);
        }

        public void ChangeSelectedViewModelToLoadedGame()
        {
            this.SelectedViewModel = this.gameViewModelFactory.CreateGameViewModelWithLoadedGame(this, this.jsonFileManager);
        }   
        
        public void ChangeSelectedViewModelToMainMenu()
        {
            this.SelectedViewModel = new MainMenuViewModel(this);
        }

    }
}