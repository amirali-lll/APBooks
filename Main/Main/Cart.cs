using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Main
{
    public class Cart
    {
        public NormalUser User { get; set; }
        public Cart(NormalUser User)
        {
            this.User = User;
        }
        public static List<Book> CartBooks { get; set; } = new List<Book>();
        public void Add(Book book)
        {
            if (!CartBooks.Contains(book))
            {
                CartBooks.Add(book);
            }
            else
            {
                MessageBox.Show("This book is already in your cart!");
            }
        }
        public void Delete(Book book)
        {
            CartBooks.Remove(book);
        }
        public void BuyWithWallet()
        {
            if (CartBooks.Count == 0)
            {
                MessageBox.Show("The cart is empty!");
            }
            else if (User.WalletMoney < CostWithDiscount())
            {
                MessageBox.Show("Your wallet's money is not enough!");
            }
            else
            {
                foreach (Book book in CartBooks)
                {
                    User.BoughtBooks.Add(book);
                }
                CartBooks.Clear();
            }
        }
        public void ManualBuy()
        {
            if (CartBooks.Count == 0)
            {
                MessageBox.Show("The cart is empty!");
            }
        }
        public double Cost()
        {
            double sum = 0;
            foreach (Book book in CartBooks)
            {
                sum = sum + book.Cost;
            }
            return sum;
        }
        public double CostWithDiscount()
        {
            double sum = 0;
            foreach (Book book in CartBooks)
            {
                sum = sum + book.CostWithDiscount();
            }
            return sum;
        }
        public double Discount()
        {
            return 100 - (CostWithDiscount() / Cost() * 100);
        }
    }
}
