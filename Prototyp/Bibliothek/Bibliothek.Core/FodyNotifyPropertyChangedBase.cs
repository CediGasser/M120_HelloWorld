namespace Bibliothek.Core
{
    using System.ComponentModel;
    using PropertyChanged;

    /// <summary>
    /// This project uses Fody.PropertyChanged to weave the OnPropertyChanged call into properties. (https://github.com/Fody/PropertyChanged)
    /// To prevent a specific class from having the notification call injection, use the <see cref="DoNotNotify"/> attribute.
    /// </summary>
    public class FodyNotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}