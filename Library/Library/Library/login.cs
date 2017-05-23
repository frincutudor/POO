using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library
{
    public partial class login : Form
    {   
        SqlConnection con=new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"c:\\users\\frincu\\documents\\visual studio 2017\\Projects\\Library\\Library\\login.mdf\";Integrated Security=True");
        int count = 0;
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM credentials WHERE username='"+textBox1.Text+"' and password='"+textBox2.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            if(count==0)
            {
                MessageBox.Show("Wrong credentials");
            }
            else
            {
                this.Hide();
                user mu = new user();
                mu.Show();
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }
    }
}
