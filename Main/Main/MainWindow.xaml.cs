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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public enum MOrU { manager, normaluser }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NormalUserButton_Click(object sender, RoutedEventArgs e)
        {
            UserLoginPage userLoginPage = new UserLoginPage();
            userLoginPage.Show();
            Close();
        }

        private void ManagerButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerLoginPage managerLoginPage = new ManagerLoginPage();
            managerLoginPage.Show();
            Close();
        }
    }
}
