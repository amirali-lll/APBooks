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
            DataContext = Book.AllBooks;
        }

        public static void InitializeNormalUserAppMainWindow(NormalUser CurrentUser)
        {
            NormalUserAppWindow appMainWindow = new NormalUserAppWindow(CurrentUser);
            appMainWindow.CurrentUserName.Text = CurrentUser.FirstName + " " + CurrentUser.LastName;
            appMainWindow.WallatMoneyAmount.Text = (int)CurrentUser.WalletMoney + "";
            appMainWindow.WalletMoneyBox.Text = (int)CurrentUser.WalletMoney + "";
            appMainWindow.CostBox.Text = (int)CurrentUser.cart.Cost() + "";
            appMainWindow.DiscountBox.Text = (int)CurrentUser.cart.Discount() + "";
            appMainWindow.TotalCostBox.Text = (int)CurrentUser.cart.CostWithDiscount() + "";
            appMainWindow.BooksNumBox.Text = CurrentUser.cart.CartBooks.Count() + "";
            if (CurrentUser.VIPSubscription != null)
            {
                appMainWindow.VIPRemainedDays.Text = CurrentUser.VIPSubscription.VIPEndingTime.Day - DateTime.Now.Day + "";
                appMainWindow.VIPRemainedDaysBox.Text = CurrentUser.VIPSubscription.VIPEndingTime.Day - DateTime.Now.Day + "";
                appMainWindow.VIPStartingDateBox.Text = CurrentUser.VIPSubscription.VIPStartingTime + "";
                appMainWindow.VIPEndingDateBox.Text = CurrentUser.VIPSubscription.VIPEndingTime + "";
                appMainWindow.FirstAndLastNameBox.Text = CurrentUser.FirstName + " " + CurrentUser.LastName;
            }
            appMainWindow.Show();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            Database.SaveAll();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void AllBooksButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = Book.AllBooks;
            MenuTab.SelectedItem = AllBooksTab;
        }

        private void MyLibraryButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = CurrentUser.BoughtBooks;
            MenuTab.SelectedItem = MyLibraryTab;
        }

        private void SearchTabButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = Book.AllBooks;
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
            DataContext = ToBeShown;
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
            DataContext = CurrentUser.cart.CartBooks;
            MenuTab.SelectedItem = CartTab;
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser.cart.BuyWithWallet();
            this.WallatMoneyAmount.Text = (int)CurrentUser.WalletMoney + "";
            this.CostBox.Text = (int)CurrentUser.cart.Cost() + "";
            this.DiscountBox.Text = (int)CurrentUser.cart.Discount() + "";
            this.TotalCostBox.Text = (int)CurrentUser.cart.CostWithDiscount() + "";
            this.BooksNumBox.Text = CurrentUser.cart.CartBooks.Count() + "";
            this.WalletMoneyBox.Text = (int)CurrentUser.WalletMoney + "";
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser.cart.CartBooks.Count == 0)
            {
                MessageBox.Show("The cart is empty!");
            }
            else
            {
                PayWindow.InitializePayWindow(CurrentUser.cart.CostWithDiscount(), CurrentUser, PayWindow.PayRequest.Cart, this);
            }
        }

        private void MyWalletButton_Click(object sender, RoutedEventArgs e)
        {
            MenuTab.SelectedItem = MyWalletTab;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddMoneyBox.Text == "")
            {
                MessageBox.Show("The adding money box is empty!");
            }
            else if(!Regex.IsMatch(AddMoneyBox.Text, @"\d"))
            {
                MessageBox.Show("You should only enter digits in add money box!");
            }
            else if(Convert.ToInt32(AddMoneyBox.Text) < 5000)
            {
                MessageBox.Show("The entered money is too small!");
            }
            else if(Convert.ToInt32(AddMoneyBox.Text) > 500000)
            {
                MessageBox.Show("The entered money is too big!");
            }
            else
            {
                PayWindow.InitializePayWindow(Convert.ToInt32(AddMoneyBox.Text), CurrentUser, PayWindow.PayRequest.Wallet, this);
            }
        }

        private void MarkedBooksButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = CurrentUser.MarkedBooks;
            MenuTab.SelectedItem = MarkedBooksTab;
        }

        private void VIPSubscriptionButton_Click(object sender, RoutedEventArgs e)
        {
            VIP.SetVIPBooks();
            DataContext = VIP.VIPBooks;
            if (CurrentUser.VIPSubscription != null)
            {
                MenuTab.SelectedItem = VIPSubscriptionTab_HasVIP;
            }
            else
            {
                MenuTab.SelectedItem = VIPSubscriptionTab_NoVIP;
                this.VIPDurationBox.Text = VIP.VIPDuration + "";
                this.VIPCostBox.Text = VIP.VIPCost + "";
            }
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
                InitializeNormalUserAppMainWindow(CurrentUser);
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
                InitializeNormalUserAppMainWindow(CurrentUser);
                Close();
            }
        }

        private void TrashButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Book b = button.DataContext as Book;
            CurrentUser.cart.Delete(b);
            this.CostBox.Text = (int)CurrentUser.cart.Cost() + "";
            this.DiscountBox.Text = (int)CurrentUser.cart.Discount() + "";
            this.TotalCostBox.Text = (int)CurrentUser.cart.CostWithDiscount() + "";
            this.BooksNumBox.Text = CurrentUser.cart.CartBooks.Count() + "";
        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Book b = button.DataContext as Book;
            CurrentUser.cart.Add(b);
            this.CostBox.Text = (int)CurrentUser.cart.Cost() + "";
            this.DiscountBox.Text = (int)CurrentUser.cart.Discount() + "";
            this.TotalCostBox.Text = (int)CurrentUser.cart.CostWithDiscount() + "";
            this.BooksNumBox.Text = CurrentUser.cart.CartBooks.Count() + "";
        }

        private void OnBookButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Book b = button.DataContext as Book;
            BookInfoWindow.InitializeBookInfoWindow(CurrentUser, b, this);
        }

        private void VIPPayButton_Click(object sender, RoutedEventArgs e)
        {
            PayWindow.InitializePayWindow(VIP.VIPCost, CurrentUser, PayWindow.PayRequest.VIP, this);
        }

        private void VIPBuyButton_Click(object sender, RoutedEventArgs e)
        {
            if(CurrentUser.WalletMoney < VIP.VIPCost)
            {
                MessageBox.Show("Your wallet money is not enough!");
            }
            else
            {
                CurrentUser.WalletMoney = CurrentUser.WalletMoney - VIP.VIPCost;
                MessageBox.Show("VIP subscription bought successfully!");
                VIP vip = new VIP();
                CurrentUser.VIPSubscription = vip;
                MenuTab.SelectedItem = VIPSubscriptionTab_HasVIP;
                this.VIPRemainedDays.Text = CurrentUser.VIPSubscription.VIPEndingTime.Day - DateTime.Now.Day + "";
                this.VIPRemainedDaysBox.Text = CurrentUser.VIPSubscription.VIPEndingTime.Day - DateTime.Now.Day + "";
                this.VIPStartingDateBox.Text = CurrentUser.VIPSubscription.VIPStartingTime + "";
                this.VIPEndingDateBox.Text = CurrentUser.VIPSubscription.VIPEndingTime + "";
                this.FirstAndLastNameBox.Text = CurrentUser.FirstName + " " + CurrentUser.LastName;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Database.SaveAll();
            Close();
        }
    }
}
