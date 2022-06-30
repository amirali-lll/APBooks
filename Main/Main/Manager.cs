using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class Manager
    {
        public string Email { get; set; }
        public string Password { get; set; }

        //Constructor:
        public Manager(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
            AllEmails.Add(Email);
        }

        //Static Collections
        public static List<string> AllEmails { get; set; } = new List<string>();
        public static List<Manager> AllManagers { get; set; } = new List<Manager>();

        //Static Methods:
        public static Manager FindManager(string Email)
        {
            foreach(Manager manager in AllManagers)
            {
                if(manager.Email == Email)
                {
                    return manager;
                }
            }
            return null;
        }
    }
}
