﻿using System;
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
        public BookInfoWindow(NormalUser CurrentUser, Book CurrentBook)
        {
            this.CurrentUser = CurrentUser;
            this.CurrentBook = CurrentBook;
            InitializeComponent();
        }
        public static void InitializeBookInfoWindow(NormalUser CurrentUser, Book book)
        {
            BookInfoWindow bookInfoWindow = new BookInfoWindow(CurrentUser, book);
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
            bookInfoWindow.Show();
        }
    }
}
