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
            //This lines will be deleted after assigning the database:
            Book book1 = new Book(1, "The Alchemist", "Pauolo Coelho", 136, 55000, 20, "");

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
    }
}
