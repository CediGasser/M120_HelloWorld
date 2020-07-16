using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Hello_World.Core;
using Hello_World.GamePage;
using Hello_World.Infrastructure.ViewModels;
using Hello_World.Infrastructure.Views;
using Hello_World.MainMenuPage;

namespace Hello_World.MainWindow
{
    public class MainWindowViewModel : ViewModelBase, ICreaterViewModel
    {
        public MainWindowViewModel()
        {
            this.SelectedPageViewModel = new MainMenuViewModel(this);
            this.Children = new List<Window>();
        }

        public IDisplayablePageViewModel SelectedPageViewModel { get; set; }

        public IList<Window> Children { get; }

        private void CloseChildren()
        {
            foreach (var child in Children)
            {
                child.Close();
            }
        }
    }
}