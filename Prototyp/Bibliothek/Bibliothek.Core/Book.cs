namespace Bibliothek.Core
{
    using System;

    public class Book : FodyNotifyPropertyChangedBase
    {
        public Book(string title, string genre, int pagesCount)
        {
            this.Title = title ?? throw new ArgumentNullException(nameof(title));
            this.Genre = genre ?? throw new ArgumentNullException(nameof(genre));
            this.PagesCount = pagesCount;
        }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int PagesCount { get; set; }
    }
}