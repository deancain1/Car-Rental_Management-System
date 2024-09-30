using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Carl_Rental_System.Model;
using Carl_Rental_System.Database;
namespace Carl_Rental_System.Forms
{
    public partial class RegisterAcc : Form
    {
        private Register_LogInAuthentication db;
        private AccountModel accountModel;

        public RegisterAcc()
        {
            InitializeComponent();
            //call the class of database
            db = new Register_LogInAuthentication();
            // call the class of model
            accountModel = new AccountModel();
        }
        private void signUp_btn_Click_1(object sender, EventArgs e)
        {
            string username = username_signUp.Text.Trim();
            string email = email_signUp.Text.Trim();
            string password = password_signUp.Text.Trim();

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        if (db.CheckUsername(username))
            {
                MessageBox.Show("Username already exists", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            accountModel.email = email;
            accountModel.username = username;
            accountModel.password = password;
            // call the query of signup
        if (db.RegisterAccount(accountModel))
            {
                MessageBox.Show("Sign Up Successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            email_signUp.Text = "";
            username_signUp.Text = "";
            password_signUp.Text = "";
         
         LogInForm form = new LogInForm();
         form.Show();
         this.Hide();
         }
        else
            {
                MessageBox.Show("Error during registration", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void login_here_btn_Click(object sender, EventArgs e)
        {
          
            LogInForm form = new LogInForm();
            form.Show();
            this.Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }
    }
}



