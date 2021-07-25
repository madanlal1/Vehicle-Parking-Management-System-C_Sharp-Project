using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vehicle_Parking_Management_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.txtUsername.Text == "admin" && this.txtPassword.Text == "admin")
            {
                this.Hide();
                MainMenu obj = new MainMenu();
                obj.Show();
            }
            else
            {
                this.label4.Text = "Invalid Username or Password!!!";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
