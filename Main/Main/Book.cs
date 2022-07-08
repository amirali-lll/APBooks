using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //Consructor:
        public Book(int id, string Name, string AuthorName, int NumberOfPages, int Cost, int DiscountPercentage, string Description)
        {
            this.id = id;
            this.Name = Name;
            this.AuthorName = AuthorName;
            this.NumberOfPages = NumberOfPages;
            this.Cost = Cost;
            this.DiscountPercentage = DiscountPercentage;
            this.Description = Description;
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
