using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    // Concrete class for magazines
    public class Magazine : Item
    {
        private string editor;
        private int yearOfPublication;

        public Magazine(string title, string editor, int yearOfPublication)
        {
            this.title = title;
            this.editor = editor;
            this.yearOfPublication = yearOfPublication;
        }

        protected override void TemplateItemInfo()
        {
            Console.WriteLine("Editor: " + editor);
            Console.WriteLine("Year of Publication: " + yearOfPublication);
        }

        public override void UpdateInfo(string newTitle, int newYearOfPublication)
        {
            title = newTitle;
            yearOfPublication = newYearOfPublication;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Magazine Info:");
            base.PrintInfo();
        }
    }

}
