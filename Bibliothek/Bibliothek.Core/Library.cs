using System.Collections.Generic;

namespace Bibliothek.Core
{
    public class Library
    {
        private List<Book> books;
        
        public ICollection<Book> Books => this.books;

        public void AddBook(Book book)
        {
            this.books.Add(book);
        }
    }
}
