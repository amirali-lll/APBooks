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
        public NormalUser CurrentUser { get; set; }
        public NormalUserAppWindow(NormalUser CurrentUser)
        {
            this.CurrentUser = CurrentUser;
            InitializeComponent();
        }
        public static void InitializeNormalUserAppMainWindow(NormalUser CurrentUser)
        {
            NormalUserAppWindow appMainWindow = new NormalUserAppWindow(CurrentUser);
            appMainWindow.CurrentUserName.Text = CurrentUser.FirstName + " " + CurrentUser.LastName;
            appMainWindow.VIPRemainedDays.Text = (CurrentUser.VIPEndingTime.Day - CurrentUser.VIPStartingTime.Day) + " days";
            appMainWindow.WallatMoneyAmount.Text = (int)CurrentUser.WalletMoney + "";
            appMainWindow.CostBox.Text = (int)CurrentUser.cart.Cost() + "";
            appMainWindow.DiscountBox.Text = (int)CurrentUser.cart.Discount() + "";
            appMainWindow.TotalCostBox.Text = (int)CurrentUser.cart.CostWithDiscount() + "";
            appMainWindow.BooksNumBox.Text = CurrentUser.cart.CartBooks.Count() + "";
            appMainWindow.WalletMoneyBox.Text = (int)CurrentUser.WalletMoney + "";
            appMainWindow.Show();
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

        private void SearchTabButton_Click(object sender, RoutedEventArgs e)
        {
            MenuTab.SelectedItem = SearchTab;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            List<Book> ToBeShown = new List<Book>();
            foreach(Book book in Book.AllBooks)
            {
                if (AllSubstrings(book.Name.ToLower()).Contains(BookNameSearchBox.Text.ToLower()) || AllSubstrings(book.AuthorName.ToLower()).Contains(AuthorNameSearchBox.Text.ToLower()))
                {
                    ToBeShown.Add(book);
                }
            }

            if(BookNameSearchBox.Text == "" && AuthorNameSearchBox.Text == "")
            {
                MessageBox.Show("You must fill at least one of the search boxes!");
            }
            else if(ToBeShown.Count == 0)
            {
                MessageBox.Show("No books found with such properties...!");
            }
        }

        public static List<string> AllSubstrings(string str)
        {
            List<string> list = new List<string>();
            for(int i = 1; i < str.Length; i++)
            {
                for(int j = 0; j < str.Length - i; j++)
                {
                    list.Add(str.Substring(j, i));
                }
            }
            return list;
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            MenuTab.SelectedItem = CartTab;
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser.cart.BuyWithWallet();
            InitializeNormalUserAppMainWindow(CurrentUser);
            Close();
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            //Opening pay window
        }

        private void MyWalletButton_Click(object sender, RoutedEventArgs e)
        {
            MenuTab.SelectedItem = MyWalletTab;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //Showing Pay Window...
        }
    }
}
