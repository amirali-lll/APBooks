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
    /// Interaction logic for ManagerSignUpPage.xaml
    /// </summary>
    public partial class ManagerSignUpPage : Window
    {
        public ManagerSignUpPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage(MOrU.manager);
            Uri uri = new Uri("https://s6.uupload.ir/files/loginbutton(manager)_sp3w.png", UriKind.Absolute);
            ImageSource imgSource = new BitmapImage(uri);
            loginPage.LoginImage.Source = imgSource;
            loginPage.Show();
            Close();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmailBox.Text == "")
            {
                MessageBox.Show("The email box could not be empty!");
            }
            else if (!CheckRegularExpressions.CheckEmailCorrection(EmailBox.Text))
            {
                MessageBox.Show("The entered email is not in the correct format!");
            }
            else if (Manager.AllEmails.Contains(EmailBox.Text))
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
            else if(PassWordBox.Password != RepeatPassWordBox.Password)
            {
                MessageBox.Show("The entered password and the repeated one are not the same!");
            }
            else
            {
                Manager manager = new Manager(EmailBox.Text, PassWordBox.Password);
                LoginPage loginPage = new LoginPage(MOrU.manager);
                MessageBox.Show("You signed up successfully!");
                loginPage.Show();
                Close();
            }
        }
    }
}
