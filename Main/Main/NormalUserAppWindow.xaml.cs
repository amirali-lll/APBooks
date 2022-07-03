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
    public partial class NormalUserAppWindow : Window
    {
        public NormalUserAppWindow(NormalUser CurrentUser)
        {
            InitializeComponent();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
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
