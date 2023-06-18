using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace libraraymanagemant
{
    public partial class member_details : Form
    {
        Form1.userName Un;
        public string username;
        public member_details(Form1.userName U1)
        {
            InitializeComponent();
            Un = U1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Book_details book_Details = new Book_details();
            book_Details.Show();
            this.Hide();


        }

        private void member_details_Load(object sender, EventArgs e)
        {
            string mysqlcon = "server=127.0.0.1; user=root; database=library; password=";
            MySqlConnection con = new MySqlConnection(mysqlcon);
            con.Open();

            username = Un.username;
            textBox1.Text = username;
            string user_id = textBox2.Text;
            string address = textBox3.Text;
            string mobile_number = textBox4.Text;

            string Query = "select * from member_database where username = '" + username + "'";

            MySqlCommand cmd = new MySqlCommand(Query,con);
            var reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                 
                textBox2.Text = reader["user_id"].ToString();
                textBox3.Text = reader["address"].ToString();
                textBox4.Text = reader["mobile_number"].ToString();
            }
            else
            {
                MessageBox.Show("Something went Wrong!");
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
