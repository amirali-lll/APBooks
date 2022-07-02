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
            LoginPage loginPage = new LoginPage(MOrU.normaluser);
            Uri uri = new Uri("https://s6.uupload.ir/files/loginbutton(normaluser)_6ccy.png", UriKind.Absolute);
            ImageSource userimgSource = new BitmapImage(uri);
            loginPage.LoginImage.Source = userimgSource; 
            loginPage.Show();
            Close();
        }

        private void ManagerButton_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage(MOrU.manager);
            Uri uri = new Uri("https://s6.uupload.ir/files/loginbutton(manager)_sp3w.png", UriKind.Absolute);
            ImageSource managerimgSource = new BitmapImage(uri);
            loginPage.LoginImage.Source = managerimgSource;
            loginPage.Show();
            Close();
        }
    }
}
