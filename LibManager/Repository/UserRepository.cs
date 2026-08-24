using LibManager.Models;
using LibManager.Interface;
using System.Text.Json;
using LibManager.Repository.Utility;
using System.Text.Json.Serialization;

namespace LibManager.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

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
        public UserRepository(string filePath)
        {
            this._filePath = filePath;
            this._users = this.LoadAll();
        }
        public void AddUser(User user)
        {
            this._users.Add(user);
            this.WriteAll();
        }

        public bool DeleteUser(User user)
        {
            if(this._users.Count == 0)
            { 
                return false;
            }
            this._users.Remove(user);
            this.WriteAll();
            return true;
        }

        public List<User> GetAllUser()
        {
            return this._users;
        }

        public User? GetUserById(Guid id)
        {
            return this._users.FirstOrDefault(user => user.Id == id);
        }

        public bool UpdateUser(User newUser)
        {
            User? user = this.GetUserById(newUser.Id);
            if (user is null)
            {
                return false;
            }
            user.UserName = newUser.UserName;
            user.Phone = newUser.Phone;
            user.Email = newUser.Email;
            user.Password = newUser.Password;
            this.WriteAll();
            return true;
        }

        private void WriteAll()
        {
            string data = JsonSerializer.Serialize(this._users, this._options);
            File.WriteAllText(this._filePath, data);
        }

        private List<User> LoadAll()
        {
            if(!File.Exists(this._filePath))
            {
                return new List<User>();
            }
            string fileData = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<User>>(fileData, this._options) ?? new List<User>();
        }

        internal bool IsUserExist(string phone, string password)
        {
            return this._users.Any(user => user.Phone == phone && user.Password == password);
        }

        internal User? GetUserByCredential(string phone, string password)
        {
            return this._users.FirstOrDefault(user => user.Phone == phone && user.Password == password);
        }
    }
}
