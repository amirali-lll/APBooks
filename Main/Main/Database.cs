using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;



//ToDo:

//in data base Users : VIP and Cart remain.
namespace Main
{
    class Database
    {

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
                double  cost            = (double)   data.Rows[i][5];
                int     discount_percen = (int)     data.Rows[i][6];
                int     n_sells         = (int)     data.Rows[i][7];
                string  imageURL        = (string)  data.Rows[i][8];
                string  PDFURL          = (string)  data.Rows[i][9];
                Book    book            = new Book(id, name, AuthorName, n_pages, description, cost, discount_percen, n_sells, imageURL, PDFURL);
            }

            conn.Close();
        }



        static public List<Manager> GetAllManagers()
        {
            List<Manager> managers = new List<Manager>();
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
                managers.Add(manager);
            }

            conn.Close();
            return managers;
        }



        

    }
}
