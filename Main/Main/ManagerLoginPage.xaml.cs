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
    /// Interaction logic for ManagerLoginPage.xaml
    /// </summary>
    public partial class ManagerLoginPage : Window
    {
        public ManagerLoginPage()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckRegularExpressions.CheckEmailValidation(EmailBox.Text, MOrU.manager))
            {
                if (CheckRegularExpressions.CheckPasswordValidation(EmailBox.Text, PassWordBox.Password, MOrU.manager))
                {
                    MessageBox.Show("Welcome " + EmailBox.Text + " !");
                    AppMainWindow appMainWindow = new AppMainWindow();
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
            ManagerSignUpPage managerSignUpPage = new ManagerSignUpPage();
            managerSignUpPage.Show();
            Close();
        }
    }
}
