using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public partial class add_books : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"c:\\users\\frincu\\documents\\visual studio 2017\\Projects\\Library\\Library\\login.mdf\";Integrated Security=True");

        public add_books()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into books values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"',"+textBox4.Text+",'"+textBox5.Text+"')";
            cmd.ExecuteNonQuery();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";


            con.Close();

            MessageBox.Show("Book inserted succesfully");
        }
    }
}
