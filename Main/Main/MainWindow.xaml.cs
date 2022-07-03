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
using System.Text.RegularExpressions;

namespace Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public enum MOrU { manager, normaluser }
    public partial class MainWindow : Window
    {
        public MOrU WichType { get; set; }
        public MainWindow()
        {
            //This lines will be deleted after assigning data base:
            NormalUser User1 = new NormalUser("Current", "User", "a@b.com", "09123456789", "AAAAaaaa");
            User1.WalletMoney = 65000;
            User1.VIPStartingTime = new DateTime(2022, 7, 1);
            User1.VIPEndingTime = new DateTime(2022, 7, 30);
            InitializeComponent();
        }

        //User or manager tab methods:
        private void NormalUserButton_Click(object sender, RoutedEventArgs e)
        {
            WichType = MOrU.normaluser;
            GoToLoginTab();
        }

        private void ManagerButton_Click(object sender, RoutedEventArgs e)
        {
            WichType = MOrU.manager;
            GoToLoginTab();
        }

        //Login tab methods:
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckRegularExpressions.CheckEmailValidation(LoginTabEmailBox.Text, WichType))
            {
                if (CheckRegularExpressions.CheckPasswordValidation(LoginTabEmailBox.Text, LoginTabPassWordBox.Password, WichType))
                {
                    MessageBox.Show("Welcome " + LoginTabEmailBox.Text + " !");
                    if(WichType == MOrU.normaluser)
                    {
                        InitializeAppMainWindow();
                    }
                    Close();
                }
            }
        }

        public void InitializeAppMainWindow()
        {
            NormalUserAppWindow appMainWindow = new NormalUserAppWindow(NormalUser.FindUser(LoginTabEmailBox.Text));
            appMainWindow.CurrentUserName.Text = NormalUser.FindUser(LoginTabEmailBox.Text).FirstName + " " + NormalUser.FindUser(LoginTabEmailBox.Text).LastName;
            appMainWindow.VIPRemainedDays.Text = (NormalUser.FindUser(LoginTabEmailBox.Text).VIPEndingTime.Day - NormalUser.FindUser(LoginTabEmailBox.Text).VIPStartingTime.Day) + " days";
            appMainWindow.WallatMoneyAmount.Text = NormalUser.FindUser(LoginTabEmailBox.Text).WalletMoney + "";
            appMainWindow.Show();
        }

        private void LoginTabBackButton_Click(object sender, RoutedEventArgs e)
        {
            IntroTab.SelectedItem = UserOrManagerTab;
        }

        public void GoToLoginTab()
        {
            IntroTab.SelectedItem = LoginTab;
            if (WichType == MOrU.normaluser)
            {
                Uri uri = new Uri("https://s6.uupload.ir/files/loginbutton(normaluser)_iwxg.png", UriKind.Absolute);
                ImageSource UserimgSource = new BitmapImage(uri);
                LoginImage.Source = UserimgSource;
            }
            else
            {
                Uri uri = new Uri("https://s6.uupload.ir/files/loginbutton(manager)_sp3w.png", UriKind.Absolute);
                ImageSource ManagerimgSource = new BitmapImage(uri);
                LoginImage.Source = ManagerimgSource;
            }
        }

        private void HereButton_Click(object sender, RoutedEventArgs e)
        {
            if(WichType == MOrU.normaluser)
            {
                IntroTab.SelectedItem = NormalUserSignUpTab;
            }
            else
            {
                IntroTab.SelectedItem = ManagerSignUpTab;
            }
        }

        //Normal user sign up tab methods:
        private void NormalUserSignUpTabSignUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEveryThingForNormalUserSignUp())
            {
                NormalUser normalUser = new NormalUser(FirstNameBox.Text, LastNameBox.Text, NormalUserSignUpTabEmailBox.Text, PhoneNumberBox.Text, NormalUserSignUpTabPassWordBox.Password);
                MessageBox.Show("You signed up successfully!");
                WichType = MOrU.normaluser;
                IntroTab.SelectedItem = LoginTab;
            }
        }

        public bool CheckEveryThingForNormalUserSignUp()
        {
            bool returned = false;
            if (FirstNameBox.Text == "")
            {
                MessageBox.Show("The name field could not be empty!");
            }
            else if (!Regex.IsMatch(FirstNameBox.Text, @"^(\w){3,32}$"))
            {
                MessageBox.Show("The entered name is not in the correct format!");
            }
            else if (LastNameBox.Text == "")
            {
                MessageBox.Show("The last name field could not be empty!");
            }
            else if (!Regex.IsMatch(LastNameBox.Text, @"^(\w){3,32}$"))
            {
                MessageBox.Show("The entered name is not in the correct format!");
            }
            else if (PhoneNumberBox.Text == "")
            {
                MessageBox.Show("The phone number box could not be empty!");
            }
            else if (!Regex.IsMatch(PhoneNumberBox.Text, @"^09(\d){9}$"))
            {
                MessageBox.Show("The phone number is not in the correct format!");
            }
            else if (NormalUserSignUpTabEmailBox.Text == "")
            {
                MessageBox.Show("The email box could not be empty!");
            }
            else if (!CheckRegularExpressions.CheckEmailCorrection(NormalUserSignUpTabEmailBox.Text))
            {
                MessageBox.Show("The entered email is not in the correct format!");
            }
            else if (NormalUser.AllEmails.Contains(NormalUserSignUpTabEmailBox.Text))
            {
                MessageBox.Show("This email has been used before! Try another one.");
            }
            else if (NormalUserSignUpTabPassWordBox.Password == "")
            {
                MessageBox.Show("The password box could not be empty!");
            }
            else if (!(Regex.IsMatch(NormalUserSignUpTabPassWordBox.Password, @"[a-z]{1,}") && Regex.IsMatch(NormalUserSignUpTabPassWordBox.Password, @"[A-Z]{1,}") && NormalUserSignUpTabPassWordBox.Password.Length >= 3 && NormalUserSignUpTabPassWordBox.Password.Length <= 40))
            {
                MessageBox.Show("The entered password is not in the correct format!");
            }
            else
            {
                returned = true;
            }
            return returned;
        }

        private void NormalUserSignUpTabBackButton_Click(object sender, RoutedEventArgs e)
        {
            GoToLoginTab();
        }


        //Manager sign up tab methods:
        private void ManagerSignUpTabSignUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEveryThingForManagerSignUp())
            {
                Manager manager = new Manager(ManagerSignUpTabEmailBox.Text, ManagerSignUpTabPassWordBox.Password);
                GoToLoginTab();
            }
        }

        public bool CheckEveryThingForManagerSignUp()
        {
            bool returned = false;
            if (ManagerSignUpTabEmailBox.Text == "")
            {
                MessageBox.Show("The email box could not be empty!");
            }
            else if (!CheckRegularExpressions.CheckEmailCorrection(ManagerSignUpTabEmailBox.Text))
            {
                MessageBox.Show("The entered email is not in the correct format!");
            }
            else if (Manager.AllEmails.Contains(ManagerSignUpTabEmailBox.Text))
            {
                MessageBox.Show("This email has been used before! Try another one.");
            }
            else if (ManagerSignUpTabPassWordBox.Password == "")
            {
                MessageBox.Show("The password box could not be empty!");
            }
            else if (!(Regex.IsMatch(ManagerSignUpTabPassWordBox.Password, @"[a-z]{1,}") && Regex.IsMatch(ManagerSignUpTabPassWordBox.Password, @"[A-Z]{1,}") && ManagerSignUpTabPassWordBox.Password.Length >= 3 && ManagerSignUpTabPassWordBox.Password.Length <= 40))
            {
                MessageBox.Show("The entered password is not in the correct format!");
            }
            else if (ManagerSignUpTabPassWordBox.Password != ManagerSignUpTabPassWordBox.Password)
            {
                MessageBox.Show("The entered password and the repeated one are not the same!");
            }
            else
            {
                returned = true;
            }
            return returned;
        }

        private void ManagerSignUpTabBackButton_Click(object sender, RoutedEventArgs e)
        {
            GoToLoginTab();
        }
    }
}
