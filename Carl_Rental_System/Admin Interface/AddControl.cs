using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carl_Rental_System.Database;
using Carl_Rental_System.Model;

    using System.Windows.Forms;

namespace Carl_Rental_System.Admin_Interface
{
    public partial class AddControl : UserControl
    {
        private AddNewCarDB db;
        private AddNewCarModel newcarmodel;
        public AddControl()
        {
            newcarmodel = new AddNewCarModel();
            db = new AddNewCarDB();
            InitializeComponent();
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {

            string Brand = brand.Text.Trim();
            string Platenumber = plateNumber.Text.Trim();
            string Carname = carName.Text.Trim();
            string PriceText = price.Text.Trim();
            string Seats = seats.Text.Trim();
            string Gas = gas.Text.Trim();
            string Transmission = transmission.Text.Trim();


            if (string.IsNullOrEmpty(Brand) ||
                string.IsNullOrEmpty(Platenumber) ||
                string.IsNullOrEmpty(Carname) ||
                string.IsNullOrEmpty(PriceText) ||
                string.IsNullOrEmpty(Seats) ||
                string.IsNullOrEmpty(Gas) ||
                string.IsNullOrEmpty(Transmission)
                )
            {
                MessageBox.Show("Please fill in all fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(PriceText, out int Price))
            {
                MessageBox.Show("Please enter a valid number for price", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (db.CheckPlateNumber(Platenumber))
            {
                MessageBox.Show("Plate number already exists", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            newcarmodel.PlateNumber = Platenumber;
            newcarmodel.CarName = Carname;

            AddNewCarModel newCarModel = new AddNewCarModel
            {
                Brand = Brand,
                PlateNumber = Platenumber,
                CarName = Carname,
                Price = Price,
                Seats = Seats,
                Gas = Gas,
                Transmission = Transmission,
                CarImage = newcarmodel.CarImage
            };
            AddNewCarDB.AddNewCars(newCarModel);
            ClearFields();
        
    }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    carImageBox.Image = Image.FromFile(openFileDialog.FileName);
                    newcarmodel.CarImage = System.IO.File.ReadAllBytes(openFileDialog.FileName);
                }
            }

        }
        private void ClearFields()
        {
            brand.Clear();
            plateNumber.Clear();
            carName.Clear();
            price.Clear();
            seats.SelectedItem = null;
            gas.SelectedItem = null;
            transmission.SelectedItem = null;
            carImageBox = null;
        }
    }
}
