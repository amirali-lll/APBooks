using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Main
{
    public class Book
    {
        //Properties:
        public int id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int NumberOfPages { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public int DiscountPercentage { get; set; }
        public int NumberOfSells { get; set; } = 0;
        public ImageSource imageSource { get; set; }
        public double costWithDiscount { get; set; }

        //Consructor:
        public Book(int id, string Name, string AuthorName, int NumberOfPages, int Cost, int DiscountPercentage, string Description, string ImageSource)
        {
            this.id = id;
            this.Name = Name;
            this.AuthorName = AuthorName;
            this.NumberOfPages = NumberOfPages;
            this.Cost = Cost;
            this.DiscountPercentage = DiscountPercentage;
            this.Description = Description;
            Uri uri = new Uri(ImageSource, UriKind.Absolute);
            ImageSource BookImgSource = new BitmapImage(uri);
            this.imageSource = BookImgSource;
            this.costWithDiscount = CostWithDiscount();
            AllBooks.Add(this);
        }

        //Methods:
        public double CostWithDiscount()
        {
            return Cost * (100 - DiscountPercentage)/100;
        }
        public double AverageRate()
        {
            double sum = 0;
            foreach (int i in Rates)
            {
                sum = sum + i;
            }
            return sum / Rates.Count;
        }

        //Static Collections:
        public static List<Book> AllBooks { get; set; } = new List<Book>();
        public static List<int> Rates { get; set; } = new List<int> { };
    }
}
