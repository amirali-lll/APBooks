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
using System.Text.RegularExpressions;

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
        public static void InitializeNormalUserAppMainWindow(NormalUser CurrentUser, string TabName)
        {
            NormalUserAppWindow appMainWindow = new NormalUserAppWindow(CurrentUser);
            appMainWindow.CurrentUserName.Text = CurrentUser.FirstName + " " + CurrentUser.LastName;
            appMainWindow.VIPRemainedDays.Text = CurrentUser.VIPEndingTime.Day - CurrentUser.VIPStartingTime.Day + "";
            appMainWindow.WallatMoneyAmount.Text = (int)CurrentUser.WalletMoney + "";
            appMainWindow.CostBox.Text = (int)CurrentUser.cart.Cost() + "";
            appMainWindow.DiscountBox.Text = (int)CurrentUser.cart.Discount() + "";
            appMainWindow.TotalCostBox.Text = (int)CurrentUser.cart.CostWithDiscount() + "";
            appMainWindow.BooksNumBox.Text = CurrentUser.cart.CartBooks.Count() + "";
            appMainWindow.WalletMoneyBox.Text = (int)CurrentUser.WalletMoney + "";
            appMainWindow.VIPRemainedDaysBox.Text = CurrentUser.VIPEndingTime.Day - CurrentUser.VIPStartingTime.Day + "";
            appMainWindow.VIPStartingDateBox.Text = CurrentUser.VIPStartingTime + "";
            appMainWindow.VIPEndingDateBox.Text = CurrentUser.VIPEndingTime + "";
            appMainWindow.MenuTab.SelectedItem = TabName;
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
            InitializeNormalUserAppMainWindow(CurrentUser, "CartTab");
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

        private void MarkedBooksButton_Click(object sender, RoutedEventArgs e)
        {
            MenuTab.SelectedItem = MarkedBooksTab;
        }

        private void VIPSubscriptionButton_Click(object sender, RoutedEventArgs e)
        {
            MenuTab.SelectedItem = VIPSubscriptionTab;
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            MenuTab.SelectedItem = ProfileTab;
        }

        private void ChangeButton1_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(ChangeFirstNameBox.Text, @"^(\w){3,32}$") && ChangeFirstNameBox.Text != "")
            {
                MessageBox.Show("The entered first name is not in the correct format!");
            }
            else if (!Regex.IsMatch(ChangeLastNameBox.Text, @"^(\w){3,32}$") && ChangeLastNameBox.Text != "")
            {
                MessageBox.Show("The entered name is not in the correct format!");
            }
            else if (!Regex.IsMatch(ChangePhoneNumberBox.Text, @"^09(\d){9}$") && ChangePhoneNumberBox.Text != "")
            {
                MessageBox.Show("The phone number is not in the correct format!");
            }
            else if (!CheckRegularExpressions.CheckEmailCorrection(ChangeEmailBox.Text) && ChangeEmailBox.Text != "")
            {
                MessageBox.Show("The entered email is not in the correct format!");
            }
            else if (NormalUser.AllEmails.Contains(ChangeEmailBox.Text) && ChangeEmailBox.Text != CurrentUser.Email && ChangeEmailBox.Text != "")
            {
                MessageBox.Show("This email has been used before! Try another one.");
            }
            else
            {
                if(ChangeFirstNameBox.Text != "")
                {
                    CurrentUser.FirstName = ChangeFirstNameBox.Text;
                    MessageBox.Show("First name changed successfully!");
                }
                if(ChangeLastNameBox.Text != "")
                {
                    CurrentUser.LastName = ChangeLastNameBox.Text;
                    MessageBox.Show("Last name changed successfully!");
                }
                if(ChangePhoneNumberBox.Text != "")
                {
                    CurrentUser.PhoneNumber = ChangePhoneNumberBox.Text;
                    MessageBox.Show("Phone number changed successfully!");
                }
                if(ChangeEmailBox.Text != "")
                {
                    CurrentUser.Email = ChangeEmailBox.Text;
                    MessageBox.Show("Email changed successfully!");
                }
                InitializeNormalUserAppMainWindow(CurrentUser, "ProfileTab");
                Close();
            }
        }

        private void ChangeButton2_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPasswordBox.Password == "")
            {
                MessageBox.Show("Current password box could not be empty!");
            }
            else if(CurrentPasswordBox.Password != CurrentUser.Password)
            {
                MessageBox.Show("Entered current password is not correct!");
            }
            else if(NewPasswordBox.Password == "")
            {
                MessageBox.Show("New password box could not be empty!");
            }
            else if (!(Regex.IsMatch(NewPasswordBox.Password, @"[a-z]{1,}") && Regex.IsMatch(NewPasswordBox.Password, @"[A-Z]{1,}") && NewPasswordBox.Password.Length >= 3 && NewPasswordBox.Password.Length <= 40))
            {
                MessageBox.Show("The entered new password is not in the correct format!");
            }
            else
            {
                CurrentUser.Password = NewPasswordBox.Password;
                InitializeNormalUserAppMainWindow(CurrentUser, "ProfileTab");
                Close();
            }
        }
    }
}
