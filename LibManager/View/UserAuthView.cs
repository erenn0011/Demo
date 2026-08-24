using LibManager.Services;

namespace LibManager.View
{
    internal class UserAuthView
    {
        private UserServices userServices;
        private BookView bookView;

        public UserAuthView(UserServices userServices, BookView bookView)
        {
            this.userServices = userServices;
            this.bookView = bookView;
        }

        internal void SignUp()
        {
            string signUpMenu = $@"
===========Sign Up Menu===========
";
            Console.WriteLine(signUpMenu);
            string? name = ViewHelper.GetName();
            if(name is null)
            {
                return;
            }
            string? phone = ViewHelper.GetPhone();
            if(phone is null)
            {
                return;
            }
            string? email = ViewHelper.GetEmail();
            if(email is null)
            {
                return;
            }
            string? password = ViewHelper.GetPassword();
            if(password is null)
            {
                return;
            }
            this.userServices.AddUserData(name, phone, email, password);
        }

        internal void Login()
        {
            string? phone = ViewHelper.GetPhone();
            if (phone is null)
            {
                return;
            }
            string? password = ViewHelper.GetPassword();
            if (password is null)
            {
                return;
            }
            if(this.userServices.UserExists(phone, password))
            {
                var user = this.userServices.GetUser(phone, password);
                if(user is null)
                {
                    Console.WriteLine("User data not avail");
                    return;
                }
                bookView.SetCurrentUser(user);
                bookView.BookMenu();
            }
            else
            {
                Console.WriteLine("Invalid data");
            }
        }
    }
}
