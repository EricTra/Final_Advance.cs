using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    // Class representing a library user
    public class LibraryUser
    {
        public string UserName { get; set; }
        public string Address { get; set; }
        public List<Item> BorrowedItems { get; set; }

        public LibraryUser(string userName, string address)
        {
            UserName = userName;
            Address = address;
            BorrowedItems = new List<Item>();
        }

        public void BorrowItem(Item item)
        {
            BorrowedItems.Add(item);
            Console.WriteLine("Item '" + item.GetTitle() + "' borrowed successfully.");
        }

        public void ReturnItem(Item item)
        {
            if (BorrowedItems.Contains(item))
            {
                BorrowedItems.Remove(item);
                Console.WriteLine("Item '" + item.GetTitle() + "' returned successfully.");
            }
            else
            {
                Console.WriteLine("Item not found in user's borrowed items.");
            }
        }

        public override string ToString()
        {
            return "User Name: " + UserName + ", Address: " + Address;
        }
    }
}