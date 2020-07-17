using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Hello_World.Core;
using Hello_World.GamePage;
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

        public IDisplayablePageViewModel SelectedPageViewModel { get; set; }
        
        public ShopViewModel ShopViewModel { get; set; }

        public IFileDialogFactory FileDialogFactory { get; }
    }
}