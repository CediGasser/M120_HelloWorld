using System;
using System.Collections.Generic;
using System.Text;
using Hello_World.Infrastructure.Views;

namespace Hello_World.Infrastructure.ViewModels
{
    interface ICreaterViewModel
    {
        public IDisplayablePageView SelectedPageView { get; set; }
    }
}
