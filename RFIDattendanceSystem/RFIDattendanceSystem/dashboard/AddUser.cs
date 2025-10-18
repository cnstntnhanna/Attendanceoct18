using RFIDattendanceSystem.database;
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

namespace RFIDattendanceSystem.dashboard
{
    public partial class AddUser : Form
        
    {
        private static DatabaseConnector connector = new DatabaseConnector();
        public string connectionString = connector.GetConnection();

        public AddUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void SaveRecord()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                using (SqlCommand command = new SqlCommand("SaveRecords ", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@user_id",tbUserID.Text);
                    command.Parameters.AddWithValue("@first_name", tbFirstName.Text);
                    command.Parameters.AddWithValue("@middle_name", tbMiddleName.Text);
                    command.Parameters.AddWithValue("@last_name", tbLastName.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Succesful inserted records!");
                }
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveRecord();
        }
    }
}
