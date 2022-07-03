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
    /// Interaction logic for AppMainWindow.xaml
    /// </summary>
    public partial class AppMainWindow : Window
    {
        public AppMainWindow(NormalUser CurrentUser)
        {
            InitializeComponent();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            InitializeLoginPageWindow();
            Close();
        }

        public static void InitializeLoginPageWindow()
        {
            LoginPage loginPage = new LoginPage(MOrU.normaluser);
            Uri uri = new Uri("https://s6.uupload.ir/files/loginbutton(normaluser)_mb6n.png", UriKind.Absolute);
            ImageSource imgSource = new BitmapImage(uri);
            loginPage.LoginImage.Source = imgSource;
            loginPage.Show();
        }

        private void AllBooksButton_Click(object sender, RoutedEventArgs e)
        {
            MenuTab.SelectedItem = AllBooksTab;
        }

        private void MyLibraryButton_Click(object sender, RoutedEventArgs e)
        {
            MenuTab.SelectedItem = MyLibraryTab;
        }
    }
}
