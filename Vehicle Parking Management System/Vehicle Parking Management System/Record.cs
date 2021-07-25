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
    public partial class Record : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["cAString"].ConnectionString;
        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VehicleParkingManagementSystem;Integrated Security=True;");
        SqlCommand command = new SqlCommand();
        public Record()
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

        private void Record_Load(object sender, EventArgs e)
        {
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from ParkingDatabase";

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);

            this.dataGridView1.DataSource = dataset.Tables[0];
        }
    }
}
