namespace Bibliothek
{
    using System.ComponentModel;

    using Bibliothek.Core;

    public class MainWindowViewModel : FodyNotifyPropertyChangedBase
    {
        private readonly Book book;

        public MainWindowViewModel(Book book)
        {
            this.book = book;
        }

        public string Title
        {
            get => this.book.Title;
            set => this.book.Title = value;
        }

        public string Genre
        {
            get => this.book.Genre;
            set => this.book.Genre = value;
        }

        public int PagesCount
        {
            get => this.book.PagesCount;
            set => this.book.PagesCount = value;
        }
    }
}
