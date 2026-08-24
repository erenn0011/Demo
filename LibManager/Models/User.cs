using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibManager.Models
{
    internal class User
    {
        internal User()
        {
        }

        public User(Guid id, string username, string phone, string email, string password)
        {
            this.Id = id;
            this.UserName = username;
            this.Phone = phone;
            this.Email = email;
            this.Password = password;
        }

        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
