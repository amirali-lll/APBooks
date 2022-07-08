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
    /// Interaction logic for ManagerAppWindow.xaml
    /// </summary>
    public partial class ManagerAppWindow : Window
    {
        public ManagerAppWindow()
        {
            InitializeComponent();
        }

        private void AddBooksButton_Click(object sender, RoutedEventArgs e)
        {
            MenuTab.SelectedItem = AddBooksTab;
        }

        private void EditBooksButton_Click(object sender, RoutedEventArgs e)
        {
            MenuTab.SelectedItem = EditBooksTab;
        }

        private void AllBooksButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = Book.AllBooks;
            MenuTab.SelectedItem = AllBooksTab;
        }

        private void UsersInfo_Click(object sender, RoutedEventArgs e)
        {
            DataContext = NormalUser.AllUsers;
            MenuTab.SelectedItem = UsersInfoTab;
        }

        private void SetDiscount_Click(object sender, RoutedEventArgs e)
        {
            MenuTab.SelectedItem = SetDiscountTab;
        }

        private void SetVIPDuration_Click(object sender, RoutedEventArgs e)
        {
            MenuTab.SelectedItem = SetVIPDurationTab;
        }

        private void StoreCashier_Click(object sender, RoutedEventArgs e)
        {
            MenuTab.SelectedItem = StoreCashier;
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
