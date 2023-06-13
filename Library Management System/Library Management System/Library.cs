using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    // Class representing a library
    public class Library
    {
        private ItemFactory itemFactory;
        private List<LibraryUser> users;
        private List<Item> items;

        public Library()
        {
            itemFactory = new ItemFactory();
            users = new List<LibraryUser>();
            items = new List<Item>();
        }

        public List<Item> GetItems()
        {
            return items;
        }

        public List<LibraryUser> GetUsers()
        {
            return users;
        }

        public void AddItem(string itemType, string title, string authorEditor, int yearOfPublication)
        {
            Item item = itemFactory.GetItem(itemType, title, authorEditor, yearOfPublication);
            items.Add(item);
            Console.WriteLine("Item added successfully.");
        }

        public void RemoveItem(Item item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                Console.WriteLine("Item removed successfully.");
            }
            else
            {
                Console.WriteLine("Item not found in the library.");
            }
        }

        public void AddUser(string userName, string address)
        {
            LibraryUser user = new LibraryUser(userName, address);
            users.Add(user);
            Console.WriteLine("User added successfully.");
        }


        public void RemoveUser(LibraryUser user)
        {
            if (users.Contains(user))
            {
                users.Remove(user);
                Console.WriteLine("User removed successfully.");
            }
            else
            {
                Console.WriteLine("User not found in the library.");
            }
        }

        public void PrintItems()
        {
            Console.WriteLine("Library Items:");
            foreach (Item item in items)
            {
                if (item is Book)
                {
                    Book book = (Book)item;
                    book.PrintInfo();
                }
                else if (item is Magazine)
                {
                    Magazine magazine = (Magazine)item;
                    magazine.PrintInfo();
                }
            }
        }

        public void PrintUsers()
        {
            Console.WriteLine("Library Users:");
            foreach (LibraryUser user in users)
            {
                Console.WriteLine(user);
            }
        }
    }
}
