using LibManager.Services;
using LibManager.Models;

namespace LibManager.View
{
    internal class BookView
    {
        private BookServices bookServices;
        private User _user;
        public BookView(BookServices bookServices)
        {
            this.bookServices = bookServices;
            this._user = new User();
        }

        internal void SetCurrentUser(User user)
        {
            _user = user;
        }

        public void BookMenu()
        {
            while (true)
            {
                string bookMenu = $@"
===========Book Menu===========
[A]dd Book
[R]emove Book
[V]iew Book
[U]pdate Book
[S]ort Book
S[E]earch Book
[L]ogout
Enter Choice: ";
                Console.Write(bookMenu);
                ConsoleKey userKey = Console.ReadKey().Key;
                switch (userKey)
                {
                    case ConsoleKey.A:
                        this.AddBook();
                        break;
                    case ConsoleKey.R:
                        this.RemoveBook();
                        break;
                    case ConsoleKey.V:
                        this.ViewBook();
                        break;
                    case ConsoleKey.U:
                        this.UpdateBook();
                        break;
                    case ConsoleKey.S:
                        this.SortBook();
                        break;
                    case ConsoleKey.E:
                        this.SearchBook();
                        break;
                    case ConsoleKey.L:
                        this._user = null;
                        return;
                    default:
                        ViewHelper.WriteColored($"Invalid choice", ConsoleColor.Red);
                        break;
                }
            }
        }

        private void AddBook()
        {
            string? bookName = ViewHelper.GetBookName();
            if (bookName is null)
            {
                return;
            }
            string? authorName = ViewHelper.GetAuthorName();
            if (authorName is null)
            {
                return;
            }
            DateOnly releaseDate = ViewHelper.GetReleaseDate();
            this.bookServices.AddBook(_user.Id, bookName, authorName, releaseDate);
        }

        private void RemoveBook()
        {
            if (this.bookServices.IsBooksEmpty(_user.Id))
            {
                ViewHelper.WriteColored($"Books are empty.", ConsoleColor.Red);
                return;
            }
            string? bookName = ViewHelper.GetBookName();
            if (bookName is null)
            {
                return;
            }
            if (this.bookServices.DeleteBook(_user.Id, bookName))
            {
                ViewHelper.WriteColored($"Deleted Book", ConsoleColor.Green);
            }
        }

        private void ViewBook()
        {
            if(this.bookServices.IsBooksEmpty(_user.Id))
            {
                ViewHelper.WriteColored($"Books are empty.", ConsoleColor.Red);
                return;
            }
            var books = this.bookServices.GetUserBooks(this._user.Id);
            foreach(var book in books)
            {
                Console.WriteLine($"Book: {book.BookName}\nAuthor Name: {book.AuthorName}\nDate: {book.ReleaseDate}");
            }
        }

        private void UpdateBook()
        {
            if (this.bookServices.IsBooksEmpty(_user.Id))
            {
                ViewHelper.WriteColored($"Books are empty.", ConsoleColor.Red);
                return;
            }
            string? oldBookName = ViewHelper.GetBookName();
            if (oldBookName is null)
            {
                return;
            }
            string? bookName = ViewHelper.GetBookName();
            if (bookName is null)
            {
                return;
            }
            string? authorName = ViewHelper.GetAuthorName();
            if (authorName is null)
            {
                return;
            }
            DateOnly releaseDate = ViewHelper.GetReleaseDate();
            if(this.bookServices.UpdateBook(_user.Id, oldBookName, bookName, authorName, releaseDate))
            {
                ViewHelper.WriteColored($"Updated", ConsoleColor.Green);
            }
            else
            {
                ViewHelper.WriteColored($"Not Updated", ConsoleColor.Red);
            }
        }

        private void SortBook()
        {
            if (this.bookServices.IsBooksEmpty(_user.Id))
            {
                ViewHelper.WriteColored($"Books are empty.", ConsoleColor.Red);
                return;
            }
            var books = this.bookServices.GetSortedBooks(this._user.Id);
            foreach (var book in books)
            {
                Console.WriteLine($"Book: {book.BookName}\nAuthor Name: {book.AuthorName}\nDate: {book.ReleaseDate}");
            }
        }

        private void SearchBook()
        {
            if (this.bookServices.IsBooksEmpty(_user.Id))
            {
                ViewHelper.WriteColored($"Books are empty.", ConsoleColor.Red);
                return;
            }
            string? bookName = ViewHelper.GetBookName();
            if (bookName is null)
            {
                return;
            }
            var books = this.bookServices.GetUserBooks(this._user.Id);
            foreach (var book in books)
            {
                if (book.BookName == bookName)
                {
                    Console.WriteLine($"Book: {book.BookName}\nAuthor Name: {book.AuthorName}\nDate: {book.ReleaseDate}");
                }
            }
        }
    }
}
