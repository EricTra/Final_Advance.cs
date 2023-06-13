using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    // Main class
    public class Program
    {
        private static Library library;
        private static List<LibraryUser> users;
        private static int choice;

        public static void Main(string[] args)
        {
            library = new Library();
            users = new List<LibraryUser>();
            choice = 0;

            while (choice != 7)
            {
                DisplayMenu();
                choice = GetChoice();

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        AddItem();
                        break;
                    case 2:
                        RemoveItem();
                        break;
                    case 3:
                        AddUser();
                        break;
                    case 4:
                        RemoveUser();
                        break;
                    case 5:
                        PrintItems();
                        break;
                    case 6:
                        PrintUsers();
                        break;
                    case 7:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----- Library Menu -----");
            Console.ResetColor();
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("3. Add User");
            Console.WriteLine("4. Remove User");
            Console.WriteLine("5. Print Items");
            Console.WriteLine("6. Print Users");
            Console.WriteLine("7. Exit");
            Console.WriteLine();
        }

        private static int GetChoice()
        {
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();
            int choice;
            int.TryParse(input, out choice);
            return choice;
        }

        private static void AddItem()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----- Add Item -----");
            Console.ResetColor();
            Console.Write("Item Type (Book/Magazine): ");
            string itemType = Console.ReadLine();
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Author/Editor: ");
            string authorEditor = Console.ReadLine();
            Console.Write("Year of Publication: ");
            int yearOfPublication;
            int.TryParse(Console.ReadLine(), out yearOfPublication);

            library.AddItem(itemType, title, authorEditor, yearOfPublication);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Item added successfully!");
            Console.ResetColor();
        }

        private static void RemoveItem()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----- Remove Item -----");
            Console.ResetColor();
            Console.Write("Enter the title of the item to remove: ");
            string title = Console.ReadLine();

            Item itemToRemove = library.GetItems().Find(item => item.GetTitle() == title);
            if (itemToRemove != null)
            {
                library.RemoveItem(itemToRemove);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Item removed successfully!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Item not found in the library.");
                Console.ResetColor();
            }
        }

        private static void AddUser()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----- Add User -----");
            Console.ResetColor();
            Console.Write("User Name: ");
            string userName = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();

            LibraryUser newUser = new LibraryUser(userName, address);
            users.Add(newUser);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("User added successfully!");
            Console.ResetColor();

            Console.WriteLine("User Actions:");
            Console.WriteLine("1. Borrow Item");
            Console.WriteLine("2. Return Item");
            Console.Write("Enter your choice: ");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    BorrowItem(newUser);
                    break;
                case "2":
                    ReturnItem(newUser);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Returning to the main menu.");
                    break;
            }
        }

        private static void RemoveUser()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----- Remove User -----");
            Console.ResetColor();
            Console.Write("Enter the address of the user to remove: ");
            string address = Console.ReadLine();

            LibraryUser userToRemove = users.Find(user => user.Address == address);
            if (userToRemove != null)
            {
                users.Remove(userToRemove);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("User removed successfully!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("User not found in the library.");
                Console.ResetColor();
            }
        }

        private static void PrintItems()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----- Items in the Library -----");
            Console.ResetColor();

            library.PrintItems();
        }

        private static void PrintUsers()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----- Users in the Library -----");
            Console.ResetColor();

            foreach (var user in users)
            {
                Console.WriteLine(user);
                Console.WriteLine("Borrowed Items:");

                if (user.BorrowedItems.Count > 0)
                {
                    foreach (var item in user.BorrowedItems)
                    {
                        Console.WriteLine($"- {item.GetTitle()} ({item.GetType().Name})");
                    }
                }
                else
                {
                    Console.WriteLine("No items borrowed.");
                }

                Console.WriteLine();
            }
        }
        private static void BorrowItem(LibraryUser user)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----- Borrow Item -----");
            Console.ResetColor();
            Console.Write("Enter the title of the item to borrow: ");
            string title = Console.ReadLine();

            Item itemToBorrow = library.GetItems().Find(item => item.GetTitle() == title);
            if (itemToBorrow != null)
            {
                user.BorrowItem(itemToBorrow);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Item borrowed successfully!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Item not found in the library.");
                Console.ResetColor();
            }
        }

        private static void ReturnItem(LibraryUser user)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----- Return Item -----");
            Console.ResetColor();
            Console.Write("Enter the title of the item to return: ");
            string title = Console.ReadLine();

            Item itemToReturn = user.BorrowedItems.Find(item => item.GetTitle() == title);
            if (itemToReturn != null)
            {
                user.ReturnItem(itemToReturn);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Item returned successfully!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Item not found in the user's borrowed items.");
                Console.ResetColor();
            }
        }
    }
}
