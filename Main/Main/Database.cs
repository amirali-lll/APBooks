﻿using System.Collections.Generic;
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
        //remain : 1-BookRates.
        static public void LoadAll()
        {
            LoadAllBooks();
            LoadAllManagers();
            LoadAllUsers();
        }


        public static void LoadAllBooks()
        {
            List<Book> books = new List<Book>();
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\db.mdf;Integrated Security=True;Connect Timeout=30");
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
                Book    book            = new Book(id, name, AuthorName, n_pages, description, cost, discount_percen, n_sells, imageURL, PDFURL);
            }

            conn.Close();
        }



        static public void LoadAllManagers()
        {
            
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\db.mdf;Integrated Security=True;Connect Timeout=30");
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



        public static void LoadAllUsers()
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
            //select from UsersVIP Rates
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





    }
}
