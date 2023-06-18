using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static libraraymanagemant.Form1;

namespace libraraymanagemant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class userName {
            public string username;
        }
        public class passWord
        {
            public string password;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            userName Un = new userName();
            Un.username = textBox1.Text;
            passWord pass = new passWord();
            pass.password = textBox2.Text;
            string mysqlCon = "server=127.0.0.1; user=root; database=library; password=";
            MySqlConnection con = new MySqlConnection(mysqlCon);
            con.Open();
            string Query = "select * from member_database where username = '" + textBox1.Text + "' and password='" + textBox2.Text + "';";
            MySqlCommand cmd = new MySqlCommand(Query, con);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            

            if(dt.Rows.Count > 0 )
            {
                Un.username = textBox1.Text;
                pass.password = textBox2.Text;

                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Try again!");
                    textBox1.Text = "";
                    textBox2.PasswordChar = '*';
                }
                else
                {
                    MessageBox.Show("Welcome!");

                    member_details MN = new member_details(Un);
                    MN.Show();
                    this.Hide();
                    
                }
            }
            else 
            {
                MessageBox.Show("Try again!");
                textBox1.Text = "";
                textBox2.Text = "";
            }

           

        }
    }
}
