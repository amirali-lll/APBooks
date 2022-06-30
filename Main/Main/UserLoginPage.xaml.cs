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
    public partial class UserLoginPage : Window
    {
        MOrU UserType { get; set; }
        public UserLoginPage(MOrU UserType)
        {
            this.UserType = UserType;
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckRegularExpressions.CheckEmailValidation(EmailBox.Text, UserType))
            {
                if(CheckRegularExpressions.CheckPasswordValidation(EmailBox.Text, PassWordBox.Password))
                {
                    if(UserType == MOrU.normaluser)
                    {
                        MessageBox.Show("Welcome " + NormalUser.FindUser(EmailBox.Text).FirstName + "!");
                    }
                    else
                    {
                        MessageBox.Show("Welcome " + EmailBox.Text + " !");
                    }
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
            if (UserType == MOrU.normaluser)
            {
                NormalUserSignUpPage normalUserSignUpPage = new NormalUserSignUpPage();
                normalUserSignUpPage.Show();
                Close();
            }
        }
    }
}

