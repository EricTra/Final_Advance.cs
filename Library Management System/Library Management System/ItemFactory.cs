using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    // Factory class for creating items
    public class ItemFactory
    {
        public Item GetItem(string itemType, string title, string authorEditor, int yearOfPublication)
        {
            switch (itemType.ToLower())
            {
                case "book":
                    return new Book(title, authorEditor, yearOfPublication);
                case "magazine":
                    return new Magazine(title, authorEditor, yearOfPublication);
                default:
                    throw new ArgumentException("Invalid item type: " + itemType);
            }
        }
    }
}
