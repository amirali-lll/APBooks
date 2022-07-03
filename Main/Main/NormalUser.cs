using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class NormalUser
    {
        //Properties:
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public double WalletMoney { get; set; } = 0;
        public int VIPRemainedDays { get; set; } = 0;
        //public Cart cart { get; set; }

        //Constructor:
        public NormalUser(string FirstName, string LastName, string Email, string PhoneNumber, string Password)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.Password = Password;
            AllEmails.Add(Email);
            AllUsers.Add(this);
            // = new Cart(this);
        }

        //Collections:
        public List<Book> BoughtBooks { get; set; } = new List<Book>();
        public List<Book> MarkedBooks { get; set; } = new List<Book>();

        //Static Collections:
        public static List<string> AllEmails { get; set; } = new List<string>();
        public static List<NormalUser> AllUsers { get; set; } = new List<NormalUser>();

        //Static Methods:
        public static NormalUser FindUser(string Email)
        {
            foreach(NormalUser user in AllUsers)
            {
                if(user.Email == Email)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
