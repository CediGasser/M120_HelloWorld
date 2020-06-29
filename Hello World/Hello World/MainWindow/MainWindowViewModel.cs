using System;
using System.Collections.Generic;
using System.Text;
using Hello_World.Core;
using Hello_World.GamePage;
using Hello_World.Infrastructure.ViewModels;
using Hello_World.Infrastructure.Views;

namespace Hello_World.MainWindow
{
    class MainWindowViewModel : ViewModelBase, ICreaterViewModel
    {
        public MainWindowViewModel(IDisplayablePageView selectedPageView)
        {
            this.SelectedPageView = selectedPageView;
        }

        public IDisplayablePageView SelectedPageView { get; set; }
    }
}