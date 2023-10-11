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
using System.Diagnostics;


namespace proect3
{
    public partial class Form3 : Form

    {

        public Form3()
        {
            InitializeComponent();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form3_Load() called...");
            textBox1.Text = "Startup...";
            try
            {

                System.Diagnostics.Debug.WriteLine("within the try");
                SqlConnection connection = new SqlConnection(@"Data 
                Source=(local)\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True"); connection.Open();
                connection.Open();
                textBox3.Text = "Connection Successful";
                connection.Close();
            }

            catch (Exception ex)
            {
                textBox3.Text = "Error, " + ex;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // label2_Click logic
            // ...
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // textBox1_TextChanged logic
            // ...
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // View Data button click event logic
            string currentTable = "";
            if (radioButton1.Checked)
            {
                currentTable = "Customers";
            }
            else if (radioButton3.Checked)
            {
                currentTable = "Employees";
            }
            else if (radioButton2.Checked)
            {
                currentTable = "Orders";
            }

            // Retrieve data and display in dataGridView1
            dataGridView1.DataSource = null;
            try


            {
                SqlCommand command = new SqlCommand();
                SqlConnection connection = new SqlConnection(@"Data 
                Source=(local)\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
                var datasource = @"(local)\SQLEXPRESS";
                //var datasource = @"DESKTOP-03B8TU4\SQLEXPRESS";
                var database = "Northwind";
                var thisUsername = Form2.username;
                var thisPassword = Form2.password;
                string connString = $"Data Source={datasource};Initial Catalog={database};Persist Security Info=True;User ID={thisUsername};Password={thisPassword}";
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                textBox3.Text = "Retrieving Records...";
                command.Connection = conn;
                command.CommandText = "SELECT * FROM " + currentTable;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                textBox3.Text = "Retrieval Successful!";
                conn.Close();
            }
            catch (Exception ex)
            {
                textBox3.Text = "Error: " + ex.Message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            // Update Database button click event logic
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            textBox3.Text = "Inserting Record...";
            command.Connection = connection;
            command.CommandText = "INSERT INTO Customers (ID, Company) VALUES('" + textBox1.Text + "','" + textBox2.Text + "')";
            command.ExecuteNonQuery();
            textBox3.Text = "Record Inserted...";
            connection.Close();
        } 

        private void button2_Click(object sender, EventArgs e)
        {
            // Count Records button click event logic
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            textBox3.Text = "Counting Records...";
            command.Connection = connection;
            command.CommandText = "SELECT COUNT(*) FROM Customers";
            int count = (int)command.ExecuteScalar();
            textBox3.Text = "Number of records: " + count;
            connection.Close();
        }
    }
}
