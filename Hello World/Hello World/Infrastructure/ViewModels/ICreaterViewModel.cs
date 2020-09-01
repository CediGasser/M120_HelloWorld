using Hello_World.Infrastructure.Views;

namespace Hello_World.Infrastructure.ViewModels
{
    internal interface ICreaterViewModel
    {
        public IDisplayableViewModel SelectedViewModel { get; set; }
    }
}