﻿using System;
using System.Collections.Generic;
using System.Text;
using Hello_World.Core;
using Hello_World.GamePage;
using Hello_World.Infrastructure.ViewModels;
using Hello_World.Infrastructure.Views;
using Hello_World.MainMenuPage;

namespace Hello_World.MainWindow
{
    class MainWindowViewModel : ViewModelBase, ICreaterViewModel
    {
        public MainWindowViewModel()
        {
            this.SelectedPageView = new MainMenuView(){ DataContext = new MainMenuViewModel(this)};
        }

        public IDisplayablePageView SelectedPageView { get; set; }
    }
}