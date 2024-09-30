using Carl_Rental_System.Database;
using Carl_Rental_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Carl_Rental_System.Forms
{
    public partial class AddCar : Form
    {
        private AddNewCarModel selectedCar;
        
        private byte[] ImageData;
   

        public AddCar()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void AddNewCar_btn_Click(object sender, EventArgs e)
        {
            if (ImageData != null) 
            {
     
                AddNewCarModel newCarModel = new AddNewCarModel
                {
                    ImageData = ImageData 

                };
                MessageBox.Show("Uploaded Image Successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AddNewCar.AddNewCars(newCarModel);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void browse_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    ImageData = File.ReadAllBytes(filePath); // Load image data as byte array
                    pictureBox1.Image = Image.FromFile(filePath); // Display the image in pictureBox
                }
            }
        }
    }
}
