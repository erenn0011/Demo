using System.Text.Json;
using System.Text.Json.Serialization;
using LibManager.Interface;
using LibManager.Models;
using LibManager.Repository.Utility;

namespace LibManager.Repository
{
    internal class BookRepository : IBookRepository
    {
        private readonly List<Books> _books;

        private readonly string _filePath;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            Converters =
            {
                new DateOnlyJsonConverter(),
                new JsonStringEnumConverter(),
            }
        };
        public BookRepository(string filePath)
        {
            this._filePath = filePath;
            this._books = this.LoadAll();
        }
        public void AddBook(Books book)
        {
            this._books.Add(book);
            this.WriteAll();
        }

        public bool DeleteBook(Books user)
        {
            if (this._books.Count == 0)
            {
                return false;
            }
            this._books.Remove(user);
            this.WriteAll();
            return true;
        }

        public List<Books> GetAllBooks(Guid id)
        {
            return this._books.Where(book => book.OwnerId == id).ToList();
        }

        public Books? GetBookById(Guid id)
        {
            return this._books.FirstOrDefault(user => user.OwnerId == id);
        }

        public bool UpdateBook(Books newBook, string oldBookName)
        {
            Books? book = this.GetUserBook(newBook.OwnerId, oldBookName);
            if (book is null)
            {
                return false;
            }
            book.BookName = newBook.BookName;
            book.AuthorName = newBook.AuthorName;
            book.ReleaseDate = newBook.ReleaseDate;

            this.WriteAll();
            return true;
        }

        private void WriteAll()
        {
            string data = JsonSerializer.Serialize(this._books, this._options);
            File.WriteAllText(this._filePath, data);
        }

        private List<Books> LoadAll()
        {
            if (!File.Exists(this._filePath))
            {
                return new List<Books>();
            }
            string fileData = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Books>>(fileData, this._options) ?? new List<Books>();
        }

        internal bool IsBooksEmpty(Guid id)
        {
            if (!File.Exists(this._filePath) || this._books.Where(book => book.OwnerId == id).Count() == 0)
            {
                return true;
            }

            return false;
        }

        internal Books? GetUserBook(Guid id, string name)
        {
            return this._books.FirstOrDefault(book => book.OwnerId == id && book.BookName == name);
        }

        internal List<Books> GetSortedBooks(Guid id)
        {
            return this._books.Where(book => book.OwnerId == id).OrderBy(book => book.BookName.ToLower()).ToList();
        }
    }
}
