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
    public partial class Form1 : Form
    {
        readonly SqlConnection Con = new SqlConnection(@" Data Source = OSAMAHAIDER; Initial Catalog = DbProject; Integrated Security = True");
        SqlCommand cmd;
        SqlDataReader sd;
        public static string setUsernameValue = "";

        string id;
        public Form1()
        {
            InitializeComponent();
        }
        public static string username;
        public static string recby
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            New_Account Acc = new New_Account();
            Acc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "User")
            {

                string q = "select * from NewAccount where Email ='" + textBox1.Text + "' and Password= '" + textBox2.Text + "' and Aprroval ='" + "Approved" + "'  ";
                SqlDataAdapter sda = new SqlDataAdapter(q, Con);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                try
                {
                    if (dtbl.Rows.Count == 1)
                    {

                        recby = textBox1.Text;
                        User_Pannel U = new User_Pannel();

                        this.Hide();
                        Con.Close();
                         setUsernameValue = textBox1.Text;
                        U.Show();


                    }
                    else
                    {
                        MessageBox.Show("Please check your Email or Pass !!");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                    }
                }
                 
                catch
                {
                    MessageBox.Show("Please check your Email or Password   !!");
                }
            }


            else if (comboBox1.Text == "Admin" && textBox1.Text=="admin" && textBox2.Text=="123")
            {
                Admin ad = new Admin();
                ad.Show();
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("Please check your Email or Pass !!");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }


        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;

        }
    }
}

