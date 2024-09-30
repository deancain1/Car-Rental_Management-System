using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Carl_Rental_System.Database;
using Carl_Rental_System.Forms;
using ComponentFactory.Krypton.Toolkit;
namespace Carl_Rental_System
{
    public partial class LogInForm : KryptonForm
    {
        private Register_LogInAuthentication db;
      

        public LogInForm()
        {
            //call the class of database
            db = new Register_LogInAuthentication();
            InitializeComponent();
        }

        private void logIn_btn_Click_1(object sender, EventArgs e)
        {
            string username = username_logIn.Text;
            string password = password_logIn.Text;

            //call the query of login
        if (db.LoginAccount(username, password))
            {
                AddCar form = new AddCar();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Register_here_btn_Click(object sender, EventArgs e)
        {
            RegisterAcc form = new RegisterAcc();
            form.Show();
            this.Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }

