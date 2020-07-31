using System;
using System.Collections.Generic;
using System.Text;
using Hello_World.Infrastructure.Views;

namespace Hello_World.Infrastructure.ViewModels
{
    interface ICreaterViewModel
    {
        public IDisplayableViewModel SelectedViewModel { get; set; }
    }
}
