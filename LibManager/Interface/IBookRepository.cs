using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibManager.Models;

namespace LibManager.Interface
{
    internal interface IBookRepository
    {
        public void AddBook(Books book);

        public bool UpdateBook(Books book, string oldBookName);

        public bool DeleteBook(Books book);

        public List<Books> GetAllBooks(Guid id);

        public Books? GetBookById(Guid id);
    }
}
