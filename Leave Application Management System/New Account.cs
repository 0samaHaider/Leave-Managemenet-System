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

namespace Leave_Application_Management_System
{
  
    public partial class New_Account : Form
    {
        readonly SqlConnection Con = new SqlConnection(@" Data Source = OSAMAHAIDER; Initial Catalog = DbProject; Integrated Security = True");
        SqlCommand cmd;
        SqlDataReader sd;
        public New_Account()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "")
            {
                Con.Open();
                string insert = "insert into NewAccount(Name, Email,Gender,Password) values ('" + textBox1.Text + "' , '" + textBox2.Text + "' ,'" + comboBox1.Text + "','" + textBox4.Text + "' )";
                cmd = new SqlCommand(insert, Con);
                cmd.ExecuteNonQuery();
                cmd.Clone();
                Con.Close();
                MessageBox.Show("Your Account has been created !!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                comboBox1.Text = "";

            }
            else
            {
                MessageBox.Show("Please Fill all Text boxes !!" );

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
