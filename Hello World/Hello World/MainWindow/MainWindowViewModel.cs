using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_World.MainWindow
{
    class MainWindowViewModel
    {
       
        private object selectedViewModel;

        public MainWindowViewModel(object selectedViewModel)
        {
            this.selectedViewModel = selectedViewModel;
        }

        public object SelectedViewModel
        {
            get => selectedViewModel;
            set => SelectedViewModel = value;
        }
    }
}