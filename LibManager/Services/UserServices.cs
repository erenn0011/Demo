using LibManager.Repository;
using LibManager.Models;

namespace LibManager.Services
{
    internal class UserServices
    {
        private UserRepository userRepository;

        public UserServices(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        internal bool AddUserData(string name, string phone, string email, string password)
        {
            User user = new User(
                Guid.NewGuid(),
                name,
                phone,
                email,
                password);
            this.userRepository.AddUser(user);
            return true;
        }

        internal User? GetUser(string phone, string password)
        {
            return this.userRepository.GetUserByCredential(phone, password);
        }

        internal bool UserExists(string phone, string password)
        {
            return this.userRepository.IsUserExist(phone, password);
        }
    }
}
