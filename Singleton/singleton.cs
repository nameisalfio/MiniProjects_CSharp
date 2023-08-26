using System;
using System.Collections.Generic;

namespace Singleton
{
    struct User
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public User(string u, string e)
        {
            Username = u;
            Email = e;
        }
        public void Print() => Console.WriteLine($"Username: {Username}\nEmail: {Email}");
    }

    class Database
    {
        // Gestisce automaticamente la creazione dell'istanza solo quando viene effettivamente richiesta la proprietà 'Value'
        private static readonly Lazy<Database> instance = new Lazy<Database>(() => new Database(), true);
        private List<User> users;

        private Database()
        {
            users = new List<User>();
            Console.WriteLine("Database created\n");
        }

        public static Database Instance => instance.Value;

        public void AddUser(User user)
        {
            users.Add(user);
            Console.WriteLine($"\nUser {user.Username} added to the registry");
        }

        public User? FindUser(string username)
        {
            return users.Find(user => user.Username == username);
        }

        public void LookUpDatabase()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("\nEmpty Database");
                return;
            }

            Console.WriteLine("Database\n");
            int idx = 0;
            foreach (var item in users)
            {
                Console.WriteLine($"\n{++idx}° User");
                item.Print();
            }
        }
    }

    class Program
    {
        public static void screen()
        {
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Find user by username");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
        }

        public static void Main(string[] args)
        {
            Database registry = Database.Instance;
            while (true)
            {
                screen();
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write("\nEnter username: ");
                            string username = Console.ReadLine();
                            Console.Write("Enter email: ");
                            string email = Console.ReadLine();
                            User newUser = new User { Username = username, Email = email };
                            registry.AddUser(newUser);
                            break;

                        case 2:
                            Console.Write("\nEnter username to search: ");
                            string searchUsername = Console.ReadLine();
                            User? outcome = registry.FindUser(searchUsername);  // un nullable va confrontato con HasValue
                            if (outcome.HasValue)
                            {
                                Console.WriteLine($"User found: Username - {outcome.Value.Username}, Email - {outcome.Value.Email}"); // estrarre prima Value
                            }
                            else
                            {
                                Console.WriteLine($"User {searchUsername} not found.");
                            }
                            break;

                        case 3:
                            Database.Instance.LookUpDatabase();
                            return;

                        default:
                            Console.WriteLine("\nInvalid choice. Please select a valid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nError {ex.Message}");
                    Environment.Exit(1);
                }
            }
        }

    }
}
