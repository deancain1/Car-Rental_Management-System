using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Carl_Rental_System.Model;
using System.Collections;

namespace Carl_Rental_System.Database
{
    public class AddNewCarDB
    {
        private static string ConnectionString = @"Data Source=LAPTOP-S6PGLPQ2;Initial Catalog = carRentalDB; Integrated Security = True;";

      
            public static void AddNewCars(AddNewCarModel newcarmodel)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();
                          String query = "INSERT INTO newCars (Brand, PlateNumber, CarName, Price, Seats, Gas, Transmission, CarImage) VALUES (@Brand, @PlateNumber, @CarName, @Price, @Seats, @Gas, @Transmission, @CarImage)";
                          SqlCommand cmd = new SqlCommand(query, conn);

                            cmd.Parameters.AddWithValue("@Brand", newcarmodel.Brand);
                            cmd.Parameters.AddWithValue("@PlateNumber", newcarmodel.PlateNumber);
                            cmd.Parameters.AddWithValue("@CarName", newcarmodel.CarName);
                            cmd.Parameters.AddWithValue("@Price", newcarmodel.Price);
                            cmd.Parameters.AddWithValue("@Seats", newcarmodel.Seats);
                            cmd.Parameters.AddWithValue("@Gas", newcarmodel.Gas);
                            cmd.Parameters.AddWithValue("@Transmission", newcarmodel.Transmission);

                            SqlParameter CarImageParam = new SqlParameter("@CarImage", SqlDbType.VarBinary);
                            CarImageParam.Value = newcarmodel.CarImage ?? (object)DBNull.Value;
                            cmd.Parameters.Add(CarImageParam);
                            cmd.ExecuteNonQuery();

                           
                        
                    }
                }

                catch (Exception ex)
                {
                   
                    MessageBox.Show($"Error adding car: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        public  bool CheckPlateNumber(string Platenumber)
        {
            string query = "SELECT COUNT (CarId) FROM newCars WHERE PlateNumber = @PlateNumber";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PlateNumber", Platenumber);

                    int count = (int)cmd.ExecuteScalar();
                    return count >= 1;
                }
            }
        }

    }
    }

