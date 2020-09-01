using System.ComponentModel;

namespace Hello_World.Infrastructure.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged, IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}