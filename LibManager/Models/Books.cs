using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibManager.Models
{
    internal class Books
    {
        public Books(Guid OwnerId, string BookName, string AuthorName, DateOnly ReleaseDate)
        {
            this.OwnerId = OwnerId;
            this.BookName = BookName;
            this.AuthorName = AuthorName;
            this.ReleaseDate = ReleaseDate;
        }

        public Guid OwnerId { get; set; }

        public string BookName { get; set; }

        public string AuthorName {  get; set; }

        public DateOnly ReleaseDate { get; set; }
    }
}
