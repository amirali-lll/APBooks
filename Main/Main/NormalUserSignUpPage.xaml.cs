using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Main
{
    /// <summary>
    /// Interaction logic for NormalUserSignUpPage.xaml
    /// </summary>
    public partial class NormalUserSignUpPage : Window
    {
        public NormalUserSignUpPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            InitializeLoginPageWindow();
            Close();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEveryThingForSignUp())
            {
                NormalUser normalUser = new NormalUser(FirstNameBox.Text, LastNameBox.Text, EmailBox.Text, PhoneNumberBox.Text, PassWordBox.Password);
                MessageBox.Show("You signed up successfully!");
                InitializeLoginPageWindow();
                Close();
            }
        }

        public static void InitializeLoginPageWindow()
        {
            LoginPage loginPage = new LoginPage(MOrU.normaluser);
            Uri uri = new Uri("https://s6.uupload.ir/files/loginbutton(normaluser)_mb6n.png", UriKind.Absolute);
            ImageSource imgSource = new BitmapImage(uri);
            loginPage.LoginImage.Source = imgSource;
            loginPage.Show();
        }

        public bool CheckEveryThingForSignUp()
        {
            bool returned = false;
            if (FirstNameBox.Text == "")
            {
                MessageBox.Show("The name field could not be empty!");
            }
            else if (!Regex.IsMatch(FirstNameBox.Text, @"^(\w){3,32}$"))
            {
                MessageBox.Show("The entered name is not in the correct format!");
            }
            else if (LastNameBox.Text == "")
            {
                MessageBox.Show("The last name field could not be empty!");
            }
            else if (!Regex.IsMatch(LastNameBox.Text, @"^(\w){3,32}$"))
            {
                MessageBox.Show("The entered name is not in the correct format!");
            }
            else if (PhoneNumberBox.Text == "")
            {
                MessageBox.Show("The phone number box could not be empty!");
            }
            else if (!Regex.IsMatch(PhoneNumberBox.Text, @"^09(\d){9}$"))
            {
                MessageBox.Show("The phone number is not in the correct format!");
            }
            else if (EmailBox.Text == "")
            {
                MessageBox.Show("The email box could not be empty!");
            }
            else if (!CheckRegularExpressions.CheckEmailCorrection(EmailBox.Text))
            {
                MessageBox.Show("The entered email is not in the correct format!");
            }
            else if (NormalUser.AllEmails.Contains(EmailBox.Text))
            {
                MessageBox.Show("This email has been used before! Try another one.");
            }
            else if (PassWordBox.Password == "")
            {
                MessageBox.Show("The password box could not be empty!");
            }
            else if (!(Regex.IsMatch(PassWordBox.Password, @"[a-z]{1,}") && Regex.IsMatch(PassWordBox.Password, @"[A-Z]{1,}") && PassWordBox.Password.Length >= 3 && PassWordBox.Password.Length <= 40))
            {
                MessageBox.Show("The entered password is not in the correct format!");
            }
            else
            {
                returned = true;
            }
            return returned;
        }
    }
}
