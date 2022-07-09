using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class VIP
    {
        public VIP(DateTime vIPStartingTime, DateTime vIPEndingTime)
        {
            VIPStartingTime = vIPStartingTime;
            VIPEndingTime = vIPEndingTime;
        }



        public DateTime VIPStartingTime { get; set; }
        public DateTime VIPEndingTime { get; set; }
        public static int VIPDuration { get; set; } = 20;
        public static double VIPCost { get; set; } = 80000;
        public VIP()
        {
            VIPStartingTime = DateTime.Now;
            VIPEndingTime = VIPStartingTime.AddDays(VIPDuration);
        }
        public static List<Book> VIPBooks { get; set; } = new List<Book>();
        public static void SetVIPBooks()
        {
            VIPBooks.Clear();
            foreach(Book book in Book.AllBooks)
            {
                if (book.IsVIP)
                {
                    VIPBooks.Add(book);
                }
            }
        }
    }
}
