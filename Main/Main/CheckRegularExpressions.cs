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
            MessageBox.Show("The entered email address is not in the correct format!");
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
        public static bool CheckPasswordValidation(string Email, string Password)
        {
            if(Password == "")
            {
                MessageBox.Show("The password box is empty!");
                return false;
            }
            else if(NormalUser.FindUser(Email).Password != Password)
            {
                MessageBox.Show("The password is not correct!");
                return false;
            }
            return true;
        }
    }
}
