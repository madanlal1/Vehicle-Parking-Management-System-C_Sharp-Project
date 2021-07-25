using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace Vehicle_Parking_Management_System
{
    public partial class Car : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["cAString"].ConnectionString;
        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VehicleParkingManagementSystem;Integrated Security=True;");
        SqlCommand command = new SqlCommand();
        public Car()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu obj2 = new MainMenu();
            obj2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "Insert into ParkingDatabase values('" + DateTime.Now.ToString() + "','" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + "Car" + "','" + "50" + "')";
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Thank you for Paying Parking Tax...");
            clearBox();
        }
        void clearBox()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
