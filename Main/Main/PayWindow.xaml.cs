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
    /// Interaction logic for PayWindow.xaml
    /// </summary>
    public partial class PayWindow : Window
    {
        public enum PayRequest { Cart, Wallet, VIP}
        public PayRequest Request { get; set;}
        public NormalUser CurrentUser;
        public NormalUserAppWindow BackWindow;
        public PayWindow(NormalUser CurrentUser, PayRequest Request, NormalUserAppWindow BackWindow)
        {
            this.BackWindow = BackWindow;
            this.CurrentUser = CurrentUser;
            this.Request = Request;
            InitializeComponent();
        }

        public static void InitializePayWindow(double Price, NormalUser CurrentUser, PayRequest Request, NormalUserAppWindow BackWindow)
        {
            PayWindow window = new PayWindow(CurrentUser, Request, BackWindow);
            window.ToBePaidPriceBox.Text = (int)Price + "";
            window.Show();
        }

        public void PayButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckRegularExpressions.CheckCardNumberCorrection(CardNumberBox.Text))
            {
                if(CheckEveryThingInPayWindow())
                {
                    MessageBox.Show("You paid " + ToBePaidPriceBox.Text + " Toman successfully!");
                    if(Request == PayRequest.Cart)
                    {
                        CurrentUser.cart.CartBooks.Clear();
                        MessageBox.Show("Books bought successfully!");
                        BackWindow.CostBox.Text = (int)CurrentUser.cart.Cost() + "";
                        BackWindow.DiscountBox.Text = (int)CurrentUser.cart.Discount() + "";
                        BackWindow.TotalCostBox.Text = (int)CurrentUser.cart.CostWithDiscount() + "";
                        BackWindow.BooksNumBox.Text = CurrentUser.cart.CartBooks.Count() + "";
                        Close();
                    }
                    else if(Request == PayRequest.Cart)
                    {
                        CurrentUser.WalletMoney = CurrentUser.WalletMoney + Convert.ToInt32(ToBePaidPriceBox.Text);
                        MessageBox.Show("Wallet charged successfully!");
                        BackWindow.WallatMoneyAmount.Text = (int)CurrentUser.WalletMoney + "";
                        BackWindow.WalletMoneyBox.Text = (int)CurrentUser.WalletMoney + "";
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("VIP subscription bought successfully!");
                        VIP vip = new VIP();
                        CurrentUser.VIPSubscription = vip;
                        BackWindow.MenuTab.SelectedItem = BackWindow.VIPSubscriptionTab_HasVIP;
                        BackWindow.VIPRemainedDays.Text = CurrentUser.VIPSubscription.VIPEndingTime.Day - DateTime.Now.Day + "";
                        BackWindow.VIPRemainedDaysBox.Text = CurrentUser.VIPSubscription.VIPEndingTime.Day - DateTime.Now.Day + "";
                        BackWindow.VIPStartingDateBox.Text = CurrentUser.VIPSubscription.VIPStartingTime + "";
                        BackWindow.VIPEndingDateBox.Text = CurrentUser.VIPSubscription.VIPEndingTime + "";
                        BackWindow.FirstAndLastNameBox.Text = CurrentUser.FirstName + " " + CurrentUser.LastName;
                    }
                }
            }
        }

        public bool CheckEveryThingInPayWindow()
        {
            bool ToBeReturned = false;
            if (CVV2Box.Text == "")
            {
                MessageBox.Show("The CVV2 box could not remain empty!");
            }
            else if (!Regex.IsMatch(CVV2Box.Text, @"\d"))
            {
                MessageBox.Show("Only numbers are allowed in CVV2 box!");
            }
            else if (CVV2Box.Text.Length < 3 || CVV2Box.Text.Length > 4)
            {
                MessageBox.Show("CVV2 length is should be 3 or 4 digits!");
            }
            else if (YearBox.Text == "")
            {
                MessageBox.Show("The year box could not remain empty!");
            }
            else if (!Regex.IsMatch(YearBox.Text, @"\d"))
            {
                MessageBox.Show("Only numbers are allowed in year box!");
            }
            else if (YearBox.Text.Length != 2)
            {
                MessageBox.Show("Year number should has 2 digits! 20{}{}");
            }
            else if (Convert.ToInt32(YearBox.Text) < 22)
            {
                MessageBox.Show("Your card is expiered!");
            }
            else if (MonthBox.Text == "")
            {
                MessageBox.Show("The month box could not remain empty!");
            }
            else if (!Regex.IsMatch(YearBox.Text, @"\d"))
            {
                MessageBox.Show("Only numbers are allowed in month box!");
            }
            else if (MonthBox.Text.Length > 2)
            {
                MessageBox.Show("Month number should has at last 2 digits!");
            }
            else if (Convert.ToInt32(MonthBox.Text) > 12 || Convert.ToInt32(MonthBox.Text) < 1)
            {
                MessageBox.Show("Month number should be a number between 1 and 12");
            }
            else if (YearBox.Text == "22" && Convert.ToInt32(MonthBox.Text) < DateTime.Now.Month)
            {
                MessageBox.Show("Your card is expiered!");
            }
            else
            {
                ToBeReturned = true;
            }
            return ToBeReturned;
        }
    }
}
