using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    // Class representing a user
    public class User
    {
        private string name;

        public User(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }
    }
}
