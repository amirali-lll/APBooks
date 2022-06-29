using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class Book
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
        public Book(int id, string Name, string AuthorName, int NumberOfPages, double Cost, int DiscountPercentage, string Description)
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

        //Methods:
        public double CostWithDiscount()
        {
            return Cost * (100 - DiscountPercentage);
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
        public List<Book> AllBooks { get; set; } = new List<Book>();
        public List<int> Rates { get; set; } = new List<int> { };
    }
}
