using LibManager.Models;
using LibManager.Repository;
using System.Xml.Linq;

namespace LibManager.Services
{
    internal class BookServices
    {
        private BookRepository _bookRepository;

        public BookServices(BookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        internal void AddBook(Guid id, string bookName, string authorName, DateOnly releaseDate)
        {
            Books book = new Books(
                id,
                bookName,
                authorName,
                releaseDate);
            this._bookRepository.AddBook(book);
        }

        internal bool DeleteBook(Guid id, string name)
        {
            Books? book = this._bookRepository.GetUserBook(id, name);
            if(book is null)
            {
                return false;
            }
            return this._bookRepository.DeleteBook(book);
        }

        internal List<Books> GetSortedBooks(Guid id)
        {
            return this._bookRepository.GetSortedBooks(id);
        }

        internal List<Books> GetUserBooks(Guid id)
        {
            return this._bookRepository.GetAllBooks(id);
        }

        internal bool IsBooksEmpty(Guid id)
        {
            return this._bookRepository.IsBooksEmpty(id);
        }

        internal bool UpdateBook(Guid id, string oldBookName, string bookName, string authorName, DateOnly releaseDate)
        {
            Books book = new Books(
                id,
                bookName,
                authorName,
                releaseDate);
            return this._bookRepository.UpdateBook(book, oldBookName);
        }
    }
}
