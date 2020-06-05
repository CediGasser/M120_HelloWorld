using System.Collections.Generic;

namespace Bibliothek.Core
{
    public class LibraryRepository
    {
        public ICollection<Library> RetrieveAllLibraries()
        {
            Library childrensBookLibrary = new Library();
            childrensBookLibrary.AddBook(new Book("Alice in Wonderland", "Fantasy", 350));
            childrensBookLibrary.AddBook(new Book("The little Prince", "Bedtime story", 80));
            childrensBookLibrary.AddBook(new Book("Snow White and the seven Dwarves", "Fantasy", 110));

            Library compSciBookLibrary = new Library();
            compSciBookLibrary.AddBook(new Book("Clean Code", "Sachbuch", 250));
            compSciBookLibrary.AddBook(new Book("Clean Coder", "Sachbuch", 210));
            compSciBookLibrary.AddBook(new Book("Clean Architecture", "Sachbuch", 270));

            return new List<Library>() { childrensBookLibrary, compSciBookLibrary };
        }
    }
}
