using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System;



//ToDo:

//in data base Users : VIP and Cart remain.
namespace Main
{
    class Database
    {
        //For fixing data base bug
        public static List<string> Covers = new List<string>();
        public static void AddCoversManually()
        {
            Covers.Add("https://s6.uupload.ir/files/the_alchemist_na3u.jpg");
            Covers.Add("https://s6.uupload.ir/files/theusdays_with_morrie_390q.jpg");
            Covers.Add("https://s6.uupload.ir/files/animal_farm_gqqa.jpg");
            Covers.Add("https://s6.uupload.ir/files/steve_jobs_suha.jpg");
            Covers.Add("https://s6.uupload.ir/files/narnia_6obx.jpg");
            Covers.Add("https://s6.uupload.ir/files/extreamly_load_and_..._9fqy.jpg");
            Covers.Add("https://s6.uupload.ir/files/shoe_dog_o58x.jpg");
            Covers.Add("https://s6.uupload.ir/files/bill_gates_tyr2.jpg");
            Covers.Add("https://s6.uupload.ir/files/mark_zuckerberg_icxr.jpg");
            Covers.Add("https://s6.uupload.ir/files/warren_buffet_zed4.jpg");
        }

        static public void LoadAll()
        {
            AddCoversManually();
            LoadAllBooks();
            LoadAllManagers();
            LoadAllUsers();
        }


        static void LoadAllBooks()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + $"{projectDirectory}\\Database\\db.mdf" + @";Integrated Security=True;Connect Timeout=30");
            conn.Open();
            string command = "SELECT * FROM Books";
            SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                int     id              = (int)     data.Rows[i][0];
                string  name            = (string)  data.Rows[i][1];
                string  AuthorName      = (string)  data.Rows[i][2];
                int     n_pages         = (int)     data.Rows[i][3];
                string  description     = (string)  data.Rows[i][4];
                double  cost            = (double)  data.Rows[i][5];
                int     discount_percen = (int)     data.Rows[i][6];
                int     n_sells         = (int)     data.Rows[i][7];
                string  imageURL        = (string)  data.Rows[i][8];
                string  PDFURL          = (string)  data.Rows[i][9];
                Book book = new Book(id, name, AuthorName, n_pages, Convert.ToInt32(cost), discount_percen, description, imageURL, false);
            }

            conn.Close();
        }



        static public void LoadAllManagers()
        {

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + $"{projectDirectory}\\Database\\db.mdf" + @";Integrated Security=True;Connect Timeout=30");
            conn.Open();
            string command = "SELECT * FROM Managers";
            SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string email = (string)data.Rows[i][1];
                string password = (string)data.Rows[i][2];
                Manager manager = new Manager(email, password);
                
            }

            conn.Close();
        }



        static void LoadAllUsers()
        {

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+$"{projectDirectory}\\Database\\db.mdf"+@";Integrated Security=True;Connect Timeout=30");
            //select from Users Table
            { 
                conn.Open();
                string command = "SELECT * FROM Users";
                SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
                DataTable data = new DataTable();
                adapter.Fill(data);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    int id = (int)data.Rows[i][0];
                    string FirstName = (string)data.Rows[i][1];
                    string LastName = (string)data.Rows[i][2];
                    string Email = (string)data.Rows[i][3];
                    string PhoneNumber = (string)data.Rows[i][4];
                    string password = (string)data.Rows[i][5];
                    double walletMoney = (double)data.Rows[i][6];
                    NormalUser user = new NormalUser(id, FirstName, LastName, Email, PhoneNumber, password, walletMoney);
                }
            }
            //select from UsersMarkedBooks Table
            {
                string command = "SELECT * FROM UsersMarkedBooks";
                var adapter = new SqlDataAdapter(command, conn);
                var data = new DataTable();

                adapter.Fill(data);

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    int bookId = (int)data.Rows[i][0];
                    int userId = (int)data.Rows[i][1];

                    Book book = Book.AllBooks.FirstOrDefault(x => x.id == bookId);
                    NormalUser user = NormalUser.AllUsers.FirstOrDefault(x => x.Id == userId);

                    user.MarkedBooks.Add(book);
                }
            }
            //select from UsersBoughtBooks Table
            {
                var command = "SELECT * FROM UsersBoughtBooks";
                var adapter = new SqlDataAdapter(command, conn);
                var data = new DataTable();

                adapter.Fill(data);

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    int bookId = (int)data.Rows[i][0];
                    int userId = (int)data.Rows[i][1];

                    Book book = Book.AllBooks.FirstOrDefault(x => x.id == bookId);
                    NormalUser user = NormalUser.AllUsers.FirstOrDefault(x => x.Id == userId);

                    user.BoughtBooks.Add(book);
                }
            }
            //select from UsersCartBooks Table
            {
                var command = "SELECT * FROM UsersCartBooks";
                var adapter = new SqlDataAdapter(command, conn);
                var data    = new DataTable();

                adapter.Fill(data);

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    int bookId = (int)data.Rows[i][0];
                    int userId = (int)data.Rows[i][1];

                    Book book = Book.AllBooks.FirstOrDefault(x => x.id == bookId);
                    NormalUser user = NormalUser.AllUsers.FirstOrDefault(x => x.Id == userId);

                    user.cart.CartBooks.Add(book);
                }
            }
            //select from VIPStatics Table
            {
                var command = "SELECT * FROM VIPStatics";
                var adapter = new SqlDataAdapter(command, conn);
                var data = new DataTable();

                adapter.Fill(data);
                double cost     = (double) data.Rows[0][0];
                int    duration = (int)    data.Rows[0][1];
                VIP.VIPCost = cost;
                
            }
            //select from UsersVIP Table
            {
                var command = "SELECT * FROM UsersVIP";
                var adapter = new SqlDataAdapter(command, conn);
                var data    = new DataTable();

                adapter.Fill(data);

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    int      userId   = (int)data.Rows[i][0];
                    DateTime start    = DateTime.Parse((string)data.Rows[i][1]);
                    DateTime end      = DateTime.Parse((string)data.Rows[i][2]);
                    




                    NormalUser user = NormalUser.AllUsers.FirstOrDefault(x => x.Id == userId);

                    VIP vip = new VIP(start, end);
                    user.VIPSubscription = vip;

                }

            }
            //select from Rates Table
            {
                string command = "SELECT * FROM Rates";
                var adapter = new SqlDataAdapter(command, conn);
                var data = new DataTable();
               
                adapter.Fill(data);
                
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    int  bookId = (int)data.Rows[i][0];
                    int  userId = (int)data.Rows[i][1];
                    int  amount = (int)data.Rows[i][2];

                    Book book   = Book.AllBooks.FirstOrDefault(x => x.id == bookId);

                    NormalUser user = NormalUser.AllUsers.FirstOrDefault(x => x.Id == userId);
                    Rate rate = new Rate(amount, user);
                    book.Rates.Add(rate);
                    
                }
                
                
            }


            conn.Close();
        }



        public static void SaveAll()
        {
            SaveAllUsers();
            SaveVIP();
            SaveBooks();
            SaveManagers();
        }


        static void SaveAllUsers()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + $"{projectDirectory}\\Database\\db.mdf" + @";Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=True");
            conn.Open();
            {
                string command1 = "DELETE FROM Users";
                SqlCommand comm = new SqlCommand(command1, conn);
                comm.BeginExecuteNonQuery();
                foreach (var user in NormalUser.AllUsers)
                {
                    string command2 = $"INSERT INTO Users VALUES({user.Id},'{user.FirstName}','{user.LastName}','{user.Email}','{user.PhoneNumber}','{user.Password}',{user.WalletMoney})";
                    SqlCommand comm2 = new SqlCommand(command2, conn);
                    comm2.BeginExecuteNonQuery();
                }
            }
            //Save Bought Books:
            {
                string command1 = "DELETE FROM UsersBoughtBooks";
                SqlCommand comm = new SqlCommand(command1, conn);
                comm.BeginExecuteNonQuery();
                foreach (var user in NormalUser.AllUsers)
                {
                    foreach (var book in user.BoughtBooks)
                    {
                        string command2 = $"INSERT INTO UsersBoughtBooks VALUES({book.id},{user.Id})";
                        SqlCommand comm2 = new SqlCommand(command2, conn);
                        comm2.BeginExecuteNonQuery();
                    }
                }
            }
            //Save Cart Books:
            {
                string command1 = "DELETE FROM UsersCartBooks";
                SqlCommand comm = new SqlCommand(command1, conn);
                comm.BeginExecuteNonQuery();
                foreach (var user in NormalUser.AllUsers)
                {
                    foreach (var book in user.cart.CartBooks)
                    {
                        string command2 = $"INSERT INTO UsersCartBooks VALUES({book.id},{user.Id})";
                        SqlCommand comm2 = new SqlCommand(command2, conn);
                        comm2.BeginExecuteNonQuery();
                    }
                }
            }
            //Save UsersMarked Books:
            {
                string command1 = "DELETE FROM UsersMarkedBooks";
                SqlCommand comm = new SqlCommand(command1, conn);
                comm.BeginExecuteNonQuery();
                foreach (var user in NormalUser.AllUsers)
                {
                    foreach (var book in user.MarkedBooks)
                    {
                        string command2 = $"INSERT INTO UsersMarkedBooks VALUES({book.id},{user.Id})";
                        SqlCommand comm2 = new SqlCommand(command2, conn);
                        comm2.BeginExecuteNonQuery();

                    }
                }
            }


        }


        static void SaveVIP()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + $"{projectDirectory}\\Database\\db.mdf" + @";Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=True");
            conn.Open();
            {
                string command1 = "DELETE FROM VIPStatics";
                SqlCommand comm = new SqlCommand(command1, conn);
                comm.BeginExecuteNonQuery();
                string command2 = $"INSERT INTO VIPStatics VALUES({VIP.VIPCost},{VIP.VIPDuration})";
                SqlCommand comm2 = new SqlCommand(command2, conn);
                comm2.BeginExecuteNonQuery();
            }

            {
                string command1 = "DELETE FROM UsersVIP";
                SqlCommand comm = new SqlCommand(command1, conn);
                comm.BeginExecuteNonQuery();
                foreach (var user in NormalUser.AllUsers)
                {
                    if(user.VIPSubscription!=null)
                    {
                        string command2 = $"INSERT INTO UsersVIP VALUES({user.Id},'{user.VIPSubscription.VIPStartingTime.ToString()}','{user.VIPSubscription.VIPEndingTime.ToString()}')";
                        SqlCommand comm2 = new SqlCommand(command2, conn);
                        comm2.BeginExecuteNonQuery();
                    }
                    
                }
            }
        }



        static void SaveBooks()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + $"{projectDirectory}\\Database\\db.mdf" + @";Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=True");
            conn.Open();
            {
                string command1 = "DELETE FROM Books";
                SqlCommand comm = new SqlCommand(command1, conn);
                comm.BeginExecuteNonQuery();
                foreach (var book in Book.AllBooks)
                {
                    string command2 = $"INSERT INTO Books VALUES" +
                                      $"({book.id},'{book.Name}'," +
                                      $"'{book.AuthorName}' ,{book.NumberOfPages}," +
                                      $"'{book.Description}',{book.Cost}," +
                                      $" {book.DiscountPercentage},{book.NumberOfSells}," +
                                      $"'{book.VIPImageSource}','{book.PDFURL}')";
                    SqlCommand comm2 = new SqlCommand(command2, conn);
                    comm2.BeginExecuteNonQuery();
                }
            }
            //Book Rates
            {
                string command1 = "DELETE FROM Rates";
                SqlCommand comm = new SqlCommand(command1, conn);
                comm.BeginExecuteNonQuery();
                foreach (var book in Book.AllBooks)
                {
                    foreach (var rate in book.Rates)
                    {
                        string command2 = $"INSERT INTO Rates VALUES" +
                              $"({book.id},{rate.user.Id},{rate.Amount})";

                        SqlCommand comm2 = new SqlCommand(command2, conn);
                        comm2.BeginExecuteNonQuery();
                    }
                }
            }
        }


        static void SaveManagers()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + $"{projectDirectory}\\Database\\db.mdf" + @";Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=True");
            conn.Open();
            string command1 = "DELETE FROM Managers";
            SqlCommand comm = new SqlCommand(command1, conn);
            foreach (var manager in Manager.AllManagers)
            {
                string command2 = $"INSERT INTO Managers VALUES" +
                              $"({manager.Email},{manager.Password})";

                SqlCommand comm2 = new SqlCommand(command2, conn);
                comm2.BeginExecuteNonQuery();
            }
        }

    }
}
