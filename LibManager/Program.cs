using System.Runtime.CompilerServices;
using LibManager.Repository;
using LibManager.Services;
using LibManager.View;

namespace LibManager
{
    internal class Program
    {
        public static void Main()
        {
            UserRepository userRepository = new UserRepository("Users.json");
            BookRepository bookRepository = new BookRepository("Books.json");

            UserServices userServices = new UserServices(userRepository);
            BookServices bookServices = new BookServices(bookRepository);

            BookView bookView = new BookView(bookServices);
            UserAuthView authView = new UserAuthView(userServices, bookView);

            while (true)
            {
                try {
                    string mainMenu = $@"
===========Main Menu===========
[S]ignUp
[L]ogIn
[E]xit
Enter Choice: ";
                    Console.Write(mainMenu);
                    ConsoleKey key = Console.ReadKey().Key;
                    switch (key)
                    {
                        case ConsoleKey.S:
                            authView.SignUp();
                            break;
                        case ConsoleKey.L:
                            authView.Login();
                            break;
                        case ConsoleKey.E:
                            ViewHelper.WriteColored($"Exiting...", ConsoleColor.Cyan);
                            Thread.Sleep(1200);
                            return;
                        default:
                            ViewHelper.WriteColored("\nInvalid Choice", ConsoleColor.Red);
                            break;
                    }
                }
                catch(Exception e)
                {
                    ViewHelper.WriteColored($"{e.Message}", ConsoleColor.Red);
                }
            }
        }
    }
}