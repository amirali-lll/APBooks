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

namespace Main
{
    /// <summary>
    /// Interaction logic for UserLoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public MOrU AccountType { get; set; }
        public LoginPage(MOrU AccountType)
        {
            InitializeComponent();
            this.AccountType = AccountType;
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckRegularExpressions.CheckEmailValidation(EmailBox.Text, AccountType))
            {
                if(CheckRegularExpressions.CheckPasswordValidation(EmailBox.Text, PassWordBox.Password, AccountType))
                {
                    MessageBox.Show("Welcome " + EmailBox.Text + " !");
                    AppMainWindow appMainWindow = new AppMainWindow();
                    appMainWindow.CurrentUserName.Text = NormalUser.FindUser(EmailBox.Text).FirstName + " " + NormalUser.FindUser(EmailBox.Text).LastName;
                    appMainWindow.Show();
                    Close();
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            Close();
        }
        private void HereButton_Click(object sender, RoutedEventArgs e)
        {
            if (AccountType == MOrU.normaluser)
            {
                NormalUserSignUpPage normalUserSignUpPage = new NormalUserSignUpPage();
                normalUserSignUpPage.Show();
                Close();
            }
            else
            {
                ManagerSignUpPage managerSignUpPage = new ManagerSignUpPage();
                managerSignUpPage.Show();
                Close();
            }
        }
    }
}

