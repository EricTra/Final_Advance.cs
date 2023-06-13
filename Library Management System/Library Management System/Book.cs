using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    // Concrete class for books
    public class Book : Item
    {
        private string author;
        private int yearOfPublication;

        public Book(string title, string author, int yearOfPublication)
        {
            this.title = title;
            this.author = author;
            this.yearOfPublication = yearOfPublication;
        }

        protected override void TemplateItemInfo()
        {
            Console.WriteLine("Author: " + author);
            Console.WriteLine("Year of Publication: " + yearOfPublication);
        }

        public override void UpdateInfo(string newTitle, int newYearOfPublication)
        {
            title = newTitle;
            yearOfPublication = newYearOfPublication;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Book Info:");
            base.PrintInfo();
        }
    }
}
