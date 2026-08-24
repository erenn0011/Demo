

using System.Runtime.CompilerServices;

namespace LibManager.View
{
    internal class ViewHelper
    {
        internal static void WriteColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        internal static string? GetName()
        {
            int MaxTries = 3;
            string? name;
            for(int i = 0; i < MaxTries; i++)
            {
                Console.Write("Name: ");
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name) && name.Length > 2)
                {
                    return name;
                }
                else
                {
                    WriteColored($"Invalid Entry [Eg: Peter]\n{MaxTries - i- 1} tries left", ConsoleColor.Red);
                }
            }
            return null;
        }

        internal static string? GetPhone()
        {
            int MaxTries = 3;
            string? value;
            for (int i = 0; i < MaxTries; i++)
            {
                Console.Write("Phone: ");
                value = Console.ReadLine();
                if (long.TryParse(value, out long phone) && phone != 0)
                {
                    return value;
                }
                else
                {
                    WriteColored($"Invalid Entry [Eg: 9345309926]\n{MaxTries - i - 1} tries left", ConsoleColor.Red);
                }
            }
            return null;
        }

        internal static string? GetEmail()
        {
            int MaxTries = 3;
            string? value;
            for (int i = 0; i < MaxTries; i++)
            {
                Console.Write("Email: ");
                value = Console.ReadLine();
                if (!string.IsNullOrEmpty(value))
                {
                    return value;
                }
                else
                {
                    WriteColored($"Invalid Entry [Eg: peter@gmail.com]\n{MaxTries - i - 1} tries left", ConsoleColor.Red);
                }
            }
            return null;
        }

        internal static string? GetPassword()
        {
            int MaxTries = 3;
            string? password;
            for (int i = 0; i < MaxTries; i++)
            {
                Console.Write("Password: ");
                password = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(password) && password.Length > 4)
                {
                    return password;
                }
                else
                {
                    WriteColored($"Invalid Entry [Eg: Peter123]\n{MaxTries - i - 1} tries left", ConsoleColor.Red);
                }
            }
            return null;
        }

        internal static string? GetBookName()
        {
            int MaxTries = 3;
            string? name;
            for (int i = 0; i < MaxTries; i++)
            {
                Console.Write("Book Name: ");
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name) && name.Length > 2)
                {
                    return name;
                }
                else
                {
                    WriteColored($"Invalid Entry [Eg: Cindrella]\n{MaxTries - i - 1} tries left", ConsoleColor.Red);
                }
            }
            return null;
        }

        internal static string? GetAuthorName()
        {
            int MaxTries = 3;
            string? name;
            for (int i = 0; i < MaxTries; i++)
            {
                Console.Write("Author Name: ");
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name) && name.Length > 2)
                {
                    return name;
                }
                else
                {
                    WriteColored($"Invalid Entry [Eg: Peter]\n{MaxTries - i - 1} tries left", ConsoleColor.Red);
                }
            }
            return null;
        }

        internal static DateOnly GetReleaseDate()
        {
            int MaxTries = 3;
            DateOnly date;
            string? data;
            for (int i = 0; i < MaxTries; i++)
            {
                Console.Write("Release Date [DD/MM/YYYY]: ");
                data = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(data) && DateOnly.TryParse(data, out date) && date < DateOnly.FromDateTime(DateTime.Today))
                {
                    return date;
                }
                else
                {
                    WriteColored($"Invalid Entry [Eg: 12/12/2012]\n{MaxTries - i - 1} tries left", ConsoleColor.Red);
                }
            }
            return DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
