using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows;

namespace Main
{
    internal class CheckRegularExpressions
    {
        public static bool CheckEmailCorrection(string Email)
        {
            if (!NormalUser.AllEmails.Contains(Email))
            {
                if (Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$"))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckEmailValidation(string Email, MOrU usertype)
        {
            if(Email == "")
            {
                MessageBox.Show("The email box is empty!");
                return false;
            }
            if (usertype == MOrU.normaluser)
            {
                if (!NormalUser.AllEmails.Contains(Email))
                {
                    MessageBox.Show("The intered email addrress is not valid!");
                    return false;
                }
            }
            else
            {
                if (!Manager.AllEmails.Contains(Email))
                {
                    MessageBox.Show("The intered email addrress is not valid!");
                    return false;
                }
            }
            return true;
        }
        public static bool CheckPasswordValidation(string Email, string Password, MOrU usertype)
        {
            if(Password == "")
            {
                MessageBox.Show("The password box is empty!");
                return false;
            }
            if(usertype == MOrU.normaluser)
            {
                if(NormalUser.FindUser(Email).Password == Password)
                {
                    return true;
                }
            }
            else if(Manager.FindManager(Email).Password == Password)
            {
                return true;
            }
            return false;
        }
    }
}
