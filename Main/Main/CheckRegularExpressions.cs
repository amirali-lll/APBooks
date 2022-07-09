using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows;

namespace Main
{
    public class CheckRegularExpressions
    {
        public static bool CheckEmailCorrection(string Email)
        {
            if (Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$"))
            {
               return true;
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
            MessageBox.Show("Incorrect password!");
            return false;
        }
        public static bool CheckCardNumberCorrection(string CardNumber)
        {
            bool ToBeReturned = false;
            if(CardNumber == "")
            {
                MessageBox.Show("The card number box could not remain empty!");
            }
            else if(!Regex.IsMatch(CardNumber, @"\d"))
            {
                MessageBox.Show("Only numbers are allowed in card number box!");
            }
            else if (!CheckLuhnAlgorithm(CardNumber))
            {
                MessageBox.Show("Entered card number doesn't match the Luhn Algorithm!");
            }
            else
            {
                ToBeReturned = true;
            }
            return ToBeReturned;
        }
        public static bool CheckLuhnAlgorithm(string Number)
        {
            int Sum = 0;
            for(int i = 1; i <= Number.Length; i++)
            {
                if(i%2 == 0)
                {
                    Sum = Sum + SumOfDigits((Convert.ToInt32(Number[Number.Length - i]) - 48) * 2);
                }
                else
                {
                    Sum = Sum + Convert.ToInt32(Number[Number.Length - i]) - 48;
                }
            }
            if(Sum%10 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int SumOfDigits(int number)
        {
            if(number < 10)
            {
                return number;
            }
            else
            {
                return 1 + number % 10;
            }
        }
    }
}
