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
    public partial class Book_details : Form
    {
        public Book_details()
        {
            InitializeComponent();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mysqlCon = "server=127.0.0.1; user=root; database=library; password=";
            MySqlConnection con = new MySqlConnection(mysqlCon);
            con.Open();

            string book_id = textBox1.Text;
            string book_name = textBox2.Text;
            string author_name = textBox3.Text;
            string book_type = textBox4.Text;

            string Query = "select * from book_database where book_id = '"+book_id+"'";

            MySqlCommand cmd = new MySqlCommand(Query,con);
            var reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                textBox1.Text = reader["book_id"].ToString();
                textBox2.Text = reader["book_name"].ToString();
                textBox3.Text = reader["author_name"].ToString() ;
                textBox4.Text = reader["book_type"].ToString();
                MessageBox.Show("Found Your Choise");

                Book_reservation book_Reservation = new Book_reservation();
                book_Reservation.Show();
                this.Hide();

            }
            else 
            {
                MessageBox.Show("Book already reserved Try Again");
            }
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
