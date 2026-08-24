using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibManager.Models;

namespace LibManager.Interface
{
    internal interface IUserRepository
    {
        public void AddUser(User user);

        public bool UpdateUser(User user);

        public bool DeleteUser(User user);

        public List<User> GetAllUser();

        public User? GetUserById(Guid id);
    }
}
