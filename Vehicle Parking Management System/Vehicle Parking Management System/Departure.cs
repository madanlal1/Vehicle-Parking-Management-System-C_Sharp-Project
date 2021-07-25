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
    public partial class Departure : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["cAString"].ConnectionString;
        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VehicleParkingManagementSystem;Integrated Security=True;");
        SqlCommand command = new SqlCommand();
        public Departure()
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
            MainMenu obj = new MainMenu();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool check = false;
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from ParkingDatabase";
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                var RegNo = (string)dataReader["Reg_No"];

                if (RegNo == textBox1.Text)
                {
                    check = true;
                }

            }
            dataReader.Close();
            if (check == true)
            {
                command.CommandText = "Delete from ParkingDatabase where Reg_No='" + textBox1.Text + "'";
                command.ExecuteNonQuery();

                MessageBox.Show("Vehicle Departed Successfully...");
                clearBox();
            }
            else
            {
                MessageBox.Show("Vehicle is not Parked! \nEither you Entered Wrong Reg_No.");
                clearBox();
            }
            connection.Close();
        }
        void clearBox()
        {
            textBox1.Text = "";
        }
    }
}
