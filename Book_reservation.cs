using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libraraymanagemant
{
    public partial class Book_reservation : Form
    {
        public Book_reservation()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mysqlcon = "server=127.0.0.1; user =root; database=library; password=";
            MySqlConnection con = new MySqlConnection(mysqlcon);
            con.Open();

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text)
                || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Fill the required Field!");
            }
            else
            {
                string book_name = textBox1.Text;
                string book_id = textBox2.Text;
                string borrowing_date = textBox3.Text;
                string return_date = textBox4.Text;
                string user_id = textBox5.Text;

                string Query = "INSERT INTO book_reservation(book_name, user_id, book_id, borrowing_date, return_date) VALUES ('" + book_name + "','" + user_id + "','" + book_id + "','" + borrowing_date + "','" + return_date + "');";

                MySqlCommand cmd = new MySqlCommand(Query,con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Book Sucessfully Reserved!");


            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Book_details book_Details = new Book_details();
            book_Details.Show();
            this.Hide();
        }
    }
}
