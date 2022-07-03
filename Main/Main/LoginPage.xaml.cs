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
            //This lines will be deleted after assigning the database to the project:
            NormalUser User1 = new NormalUser("Current", "User", "a@b.com", "09123456789", "AAAAaaaa");
            User1.WalletMoney = 15000;
            User1.VIPStartingTime = new DateTime(2022, 7, 1);
            User1.VIPEndingTime = new DateTime(2022, 7, 16);

            if (CheckRegularExpressions.CheckEmailValidation(EmailBox.Text, AccountType))
            {
                if(CheckRegularExpressions.CheckPasswordValidation(EmailBox.Text, PassWordBox.Password, AccountType))
                {
                    MessageBox.Show("Welcome " + EmailBox.Text + " !");
                    AppMainWindow appMainWindow = new AppMainWindow(NormalUser.FindUser(EmailBox.Text));
                    appMainWindow.CurrentUserName.Text = NormalUser.FindUser(EmailBox.Text).FirstName + " " + NormalUser.FindUser(EmailBox.Text).LastName;
                    appMainWindow.VIPRemainedDays.Text = (NormalUser.FindUser(EmailBox.Text).VIPEndingTime.Day - NormalUser.FindUser(EmailBox.Text).VIPStartingTime.Day) + " days";
                    appMainWindow.WallatMoneyAmount.Text = NormalUser.FindUser(EmailBox.Text).WalletMoney + "";
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

