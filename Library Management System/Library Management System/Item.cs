using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    // Abstract class for library items
    public abstract class Item
    {
        protected string title;

        public string GetTitle()
        {
            return title;
        }

        // Template method
        public void PrintInfo()
        {
            Console.WriteLine("Title: " + title);
            TemplateItemInfo();
            Console.WriteLine();
        }

        // Abstract method to be implemented by subclasses
        protected abstract void TemplateItemInfo();
        public abstract void UpdateInfo(string newTitle, int newYearOfPublication);
    }
}
