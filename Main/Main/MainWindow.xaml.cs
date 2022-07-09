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
            Database.LoadAll();
            //This lines will be deleted after assigning data base:
            //Book book1 = new Book(1, "The Alchemist", "Pauolo Coelho", 136, 55000, 20, "The Alchemist is a novel by Brazilian author Paulo Coelho which was first published in 1988. Originally written in Portuguese, it became a widely translated international bestseller.", "https://s6.uupload.ir/files/the_alchemist_na3u.jpg", true);
            //Book book2 = new Book(2, "Theusdays with Morrie", "Mitch Albom", 340, 60000, 30, "Tuesdays with Morrie is a memoir by American author Mitch Albom about a series of visits Albom made to his former sociology professor Morrie Schwartz, as Schwartz gradually dies of ALS.", "https://s6.uupload.ir/files/theusdays_with_morrie_390q.jpg", false);
            //Book book3 = new Book(3, "Animal Farm", "George Orwell", 168, 45000, 0, "Animal Farm is a satirical allegorical novella by George Orwell, first published in England on 17 August 1945. The book tells the story of a group of farm animals who rebel against their human farmer, hoping to create a society where the animals can be equal, free, and happy. ", "https://s6.uupload.ir/files/animal_farm_gqqa.jpg", true);
            //Book book4 = new Book(4, "Steve Jobs", "Walter Isaacson", 590, 100000, 35, "Steve Jobs is the authorized self-titled biography of American business magnate and Apple co-founder Steve Jobs. The book was written at the request of Jobs by Walter Isaacson, a former executive at CNN and TIME who has written best-selling biographies of Benjamin Franklin and Albert Einstein.", "https://s6.uupload.ir/files/steve_jobs_suha.jpg", false);
            //Book book5 = new Book(5, "The Chronicles of Narnia", "C. S. Lewis", 768, 180000, 0, "The Chronicles of Narnia is a series of seven fantasy novels by British author C. S. Lewis. Illustrated by Pauline Baynes and originally published between 1950 and 1956, The Chronicles of Narnia has been adapted for radio, television, the stage, film and video games.", "https://s6.uupload.ir/files/narnia_6obx.jpg", false);
            //Book book6 = new Book(6, "Extremely Loud and Incredibly Close", "Jonathan Safran Foer", 374, 50000, 10, "Oskar, a child suffering from a developmental disorder, sets out to discover a message left by his father when he accidentally comes across a mysterious key.", "https://s6.uupload.ir/files/extreamly_load_and_..._9fqy.jpg", false);
            //Book book7 = new Book(7, "Shoe Dog", "Phil Knight", 400, 70000, 50, "Shoe Dog is a memoir by Nike co-founder Phil Knight. The memoir chronicles the history of Nike from its founding as Blue Ribbon Sports and its early challenges to its evolution into one of the world's most recognized and profitable companies. It also highlights certain parts of Phil Knight's life.", "https://s6.uupload.ir/files/shoe_dog_o58x.jpg", true);
            //Book book8 = new Book(8, "Bill Gates In His Own Words", "Lisa Rogak", 208, 50000, 15, "Get inside the head of one of the most important leaders of our time with this collection of quotes from—global business icon and philanthropist Bill Gates, the co-founder and former CEO of Microsoft.", "https://s6.uupload.ir/files/bill_gates_tyr2.jpg", false);
            Book book9 = new Book(9, "Mark Zuckerberg In His Own Words", "George Beahm", 208, 50000, 15, "Mark Zuckerberg: In His Own Words details the visionary thoughts and opinions of Facebook's founder entirely through direct quotations from Zuckerberg himself. It is an intimate and authoritative look at the man behind Facebook's once-in-a-generation success.", "https://s6.uupload.ir/files/mark_zuckerberg_icxr.jpg", true);
            Book book10 = new Book(11, "Warren Buffett In His Own Words", "David Andrews", 208, 50000, 15, "Warren Buffett: In His Own Words is a comprehensive guidebook to the inner workings of this business icon, providing insight into his thoughts on investing, Wall Street, business, politics, taxes, life lessons, and more.", "https://s6.uupload.ir/files/warren_buffet_zed4.jpg", true);
            NormalUser User1 = new NormalUser("Current", "User", "a@b.com", "09123456789", "AAAAaaaa");
            User1.WalletMoney = 65000;
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
                        NormalUser CurrentUser = NormalUser.FindUser(LoginTabEmailBox.Text);
                        NormalUserAppWindow.InitializeNormalUserAppMainWindow(CurrentUser);
                    }
                    else
                    {
                        Manager CurrentManager = Manager.FindManager(LoginTabEmailBox.Text);
                        ManagerAppWindow managerAppWindow = new ManagerAppWindow();
                        managerAppWindow.Show();
                    }
                    Close();
                }
            }
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

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Database.SaveAll();
            Close();
        }
    }
}
