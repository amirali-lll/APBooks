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
    /// Interaction logic for BookInfoWindow.xaml
    /// </summary>
    public partial class BookInfoWindow : Window
    {
        public NormalUser CurrentUser { get; set; }
        public Book CurrentBook { get; set; }
        public NormalUserAppWindow BackWindow { get; set; }
        public BookInfoWindow(NormalUser CurrentUser, Book CurrentBook, NormalUserAppWindow BackWindow)
        {
            this.BackWindow = BackWindow;
            this.CurrentUser = CurrentUser;
            this.CurrentBook = CurrentBook;
            InitializeComponent();
        }
        public static void InitializeBookInfoWindow(NormalUser CurrentUser, Book book, NormalUserAppWindow BackWindow)
        {
            BookInfoWindow bookInfoWindow = new BookInfoWindow(CurrentUser, book, BackWindow);
            if (CurrentUser.BoughtBooks.Contains(book))
            {
                Uri uri1 = new Uri("https://s6.uupload.ir/files/book_info_page(bought)_3vqv.png", UriKind.Absolute);
                ImageSource BookImgSource = new BitmapImage(uri1);
                bookInfoWindow.BackgroundImage.ImageSource = BookImgSource;
            }
            bookInfoWindow.BookCover.Source = book.CoverSource;
            bookInfoWindow.BookNameBox.Text = book.Name;
            bookInfoWindow.AuthorNameBox.Text = book.AuthorName;
            bookInfoWindow.NumberOfPagesBox.Text = book.NumberOfPages + "";
            bookInfoWindow.DescriptionBox.Text = book.Description;
            bookInfoWindow.VIPImage.Source = book.VIPImageSource;
            if (CurrentUser.MarkedBooks.Contains(book))
            {
                Uri uri1 = new Uri("https://s6.uupload.ir/files/bookmarked_7x7x.png", UriKind.Absolute);
                ImageSource BookImgSource = new BitmapImage(uri1);
                bookInfoWindow.BookMarkImage.Source = BookImgSource;
            }
            bookInfoWindow.Show();
        }

        private void MarkItButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser.MarkedBooks.Contains(CurrentBook))
            {
                MessageBox.Show("This book have already been marked for you!");
            }
            else
            {
                CurrentUser.MarkedBooks.Add(CurrentBook);
                MessageBox.Show("This book successfully marked for you!");
                Uri uri1 = new Uri("https://s6.uupload.ir/files/bookmarked_7x7x.png", UriKind.Absolute);
                ImageSource BookImgSource = new BitmapImage(uri1);
                this.BookMarkImage.Source = BookImgSource;
            }
        }

        private void RedButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser.BoughtBooks.Contains(CurrentBook))
            {

            }
            else
            {
                CurrentUser.cart.Add(CurrentBook);
                BackWindow.CostBox.Text = (int)CurrentUser.cart.Cost() + "";
                BackWindow.DiscountBox.Text = (int)CurrentUser.cart.Discount() + "";
                BackWindow.TotalCostBox.Text = (int)CurrentUser.cart.CostWithDiscount() + "";
                BackWindow.BooksNumBox.Text = CurrentUser.cart.CartBooks.Count() + "";
            }
        }
    }
}
