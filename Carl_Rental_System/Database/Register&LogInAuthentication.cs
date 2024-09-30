using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Carl_Rental_System.Model;
using System.Windows.Forms;
namespace Carl_Rental_System.Database
{
   public class Register_LogInAuthentication
    {
        private static string ConnectionString = @"Data Source=LAPTOP-S6PGLPQ2\SQLEXPRESS;Initial Catalog=car_rental.db;Integrated Security=True;";
        public bool LoginAccount(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    String query = "SELECT COUNT(1) FROM admin WHERE username = @username AND password = @password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool CheckUsername(string Username)
        {
            string query = "SELECT COUNT (id) FROM admin WHERE username = @username";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", Username);

                    int count = (int)cmd.ExecuteScalar();
                    return count >= 1;
                }
            }
        }
        public bool RegisterAccount(AccountModel accountModel)
               {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO admin (email, username, password) VALUES (@email, @username, @password)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@email", accountModel.email);
                    cmd.Parameters.AddWithValue("@username", accountModel.username);
                    cmd.Parameters.AddWithValue("@password", accountModel.password);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

  
    }
}
