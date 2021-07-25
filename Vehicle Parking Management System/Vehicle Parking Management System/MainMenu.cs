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
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace Vehicle_Parking_Management_System
{
    public partial class MainMenu : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["cAString"].ConnectionString;
        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VehicleParkingManagementSystem;Integrated Security=True;");
        SqlCommand command = new SqlCommand();
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "Delete from ParkingDatabase";
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Database Reset");
            this.lblParked.Text = "Vehicle Parked: 0";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Car obj = new Car();
            obj.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bike obj2 = new Bike();
            obj2.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rikshaw obj3 = new Rikshaw();
            obj3.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bus obj4 = new Bus();
            obj4.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Hide();
            AboutUs obj5 = new AboutUs();
            obj5.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Departure obj6 = new Departure();
            obj6.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Record obj7 = new Record();
            obj7.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            int count = 0;
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from ParkingDatabase";

            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                count++;
            }

            dataReader.Close();
            connection.Close();
            this.lblParked.Text = "Vehicle Parked: " + count;
        }
    }
}
