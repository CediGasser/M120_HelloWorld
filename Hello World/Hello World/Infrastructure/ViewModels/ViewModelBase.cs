using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hello_World.Infrastructure.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged, IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
