using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Carl_Rental_System.Model;
namespace Carl_Rental_System.Database
{
    public class AddNewCar
    {


        private static string ConnectionString = @"Data Source=LAPTOP-S6PGLPQ2\SQLEXPRESS;Initial Catalog=car_rental.db;Integrated Security=True;";
        public static void AddNewCars(AddNewCarModel newcarmodel)
        {
            try
            {
             
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand
                        ("INSERT INTO New_Cars ( ImageData) " +
                        "VALUES (@ImageData)", conn))
                    {
                       

                        SqlParameter CoverImageParam = new SqlParameter("@ImageData", SqlDbType.VarBinary);
                        CoverImageParam.Value = newcarmodel.ImageData ?? (object)DBNull.Value;
                        cmd.Parameters.Add(CoverImageParam);
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Adding Manga {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

