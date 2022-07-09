using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;

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
        public string DiscountPercentageText { get; set; } //not in db
        public int NumberOfSells { get; set; } = 0; //not in db
        public ImageSource CoverSource { get; set; } //db as string
        public double costWithDiscount { get; set; } //not in db
        public bool IsVIP { get; set; }
        public ImageSource VIPImageSource { get; set; } //not in db
        public string PDFURL { get; set; } = "";
        public List<Rate> Rates { get; set; } = new List<Rate>();

        //Consructor:
        public Book(int id, string Name, string AuthorName, int NumberOfPages, int Cost, int DiscountPercentage, string Description, string CoverSource, bool IsVIP)
        {
            this.id = id;
            this.Name = Name;
            this.AuthorName = AuthorName;
            this.NumberOfPages = NumberOfPages;
            this.Cost = Cost;
            this.DiscountPercentage = DiscountPercentage;
            this.Description = Description;
            Uri uri = new Uri(Database.Covers[Book.AllBooks.Count], UriKind.Absolute);
            ImageSource BookImgSource = new BitmapImage(uri);
            this.CoverSource = BookImgSource;
            this.costWithDiscount = CostWithDiscount();
            this.IsVIP = IsVIP;
            DiscountPercentageText = DiscountPercentage + "%";
            if (IsVIP)
            {
                Uri uri2 = new Uri("https://s6.uupload.ir/files/vipstar_g9d.png", UriKind.Absolute);
                ImageSource VIPImgSource = new BitmapImage(uri2);
                this.VIPImageSource = VIPImgSource;
            }
            AllBooks.Add(this);
        }
        //Consructor for db load:
        public Book(int id, string name, string authorName, int numberOfPages, string description, double cost, int discountPercentage, int numberOfSells , string imageURL,string PDFURL)
        {
            this.id = id;
            Name = name;
            AuthorName = authorName;
            NumberOfPages = numberOfPages;
            Description = description;
            Cost = cost;
            DiscountPercentage = discountPercentage;
            NumberOfSells = numberOfSells;
            if (imageURL != "")
            {
                Uri uri = new Uri(Database.Covers[id], UriKind.Absolute);
                ImageSource BookImgSource = new BitmapImage(uri);
                this.CoverSource = BookImgSource;
            }
            this.costWithDiscount = CostWithDiscount();
            this.PDFURL = PDFURL;
            DiscountPercentageText = DiscountPercentage + "%";
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
            foreach(Rate rate in Rates)
            {
                sum = sum + rate.Amount;
            }
            return sum/ Rates.Count;
        }

        //Static Collections:
        public static List<Book> AllBooks { get; set; } = new List<Book>();
    }
}
