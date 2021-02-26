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
    public partial class User_Pannel : Form
    {
        readonly SqlConnection Con = new SqlConnection(@" Data Source = OSAMAHAIDER; Initial Catalog = DbProject; Integrated Security = True");
        SqlCommand cmd;
        SqlDataReader sd;
      //  public int b = 100;
      //   public int d = 5;
        public  int s;

        public User_Pannel()
        {
            InitializeComponent();
        }
        public void retrieveUserInfo()
        {
            //  Retrieve();
            Con.Open();
            string del = "Select * from  NewAccount where Email='" + textBox1.Text + "'";
            cmd = new SqlCommand(del, Con);
            cmd.ExecuteNonQuery();
            SqlDataReader DR1 = cmd.ExecuteReader();
            if (DR1.Read())
            {
                textBox2.Text = DR1.GetValue(1).ToString();
                textBox3.Text = DR1.GetValue(0).ToString();
                textBox7.Text = DR1.GetValue(1).ToString();
                textBox8.Text = DR1.GetValue(0).ToString();


            }
           
            cmd.Clone();
            Con.Close();
        }
        public void Calculatebonus ()
        {
            ShowData1();
            int countrow = dataGridView1.Rows.Count;
           int  b = 131 - countrow;
            textBox9.Text = b.ToString();



        }
        public void calculateLeaves ()
        {
            ShowData1();

            int countrow = dataGridView1.Rows.Count;
           // if (dataGridView1.Rows.Count ==31)
          //  {
                int s;
                s = 31 - countrow;
                textBox4.Text = s.ToString();
          //  }
          
        }
        private void User_Pannel_Load(object sender, EventArgs e)
        {
            LEaveModule.Visible = false;
            LeaveStatus.Visible = false;
            MarkAttendance.Visible = false;
            ShowData1();
            timer1.Start();
            showleavestatus();

            int countrow = dataGridView1.Rows.Count;
            if (dataGridView1.Rows.Count >31)
            {
                int m = 0;
                textBox4.Text = m.ToString();
                Calculatebonus();

            }
            
          //  Calculatebonus();
            label4.Text = DateTime.Now.ToLongDateString();
            label5.Text = DateTime.Now.ToLongTimeString();
            label13.Text = DateTime.Now.ToLongDateString();
            label14.Text = DateTime.Now.ToLongTimeString();


            textBox1.Text = Form1.recby;
            retrieveUserInfo();
            calculateLeaves();
            ShowData1();




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();

            label5.Text = DateTime.Now.ToLongTimeString();
            label14.Text = DateTime.Now.ToLongTimeString();



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowData1();
        }
        
        public void ShowData1()
        {
            Con.Open();
            string st = "Select ID,Name,Reason,Date,Address,Leave_Type from LeaveMod where ID='" + textBox3.Text + "'";
            cmd = new SqlCommand(st, Con);
            DataTable data = new DataTable();
            sd = cmd.ExecuteReader();
            data.Load(sd);
            dataGridView1.DataSource = data;
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int countrow = dataGridView1.Rows.Count;
            if (dataGridView1.Rows.Count <31)
            {
                

                Con.Open();
                string str = "insert into LeaveMod(ID,Name,Reason,Date,Address,Leave_Type) Values ('" + textBox3.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "')";
                cmd = new SqlCommand(str, Con);
                cmd.ExecuteNonQuery();
                cmd.Clone();
                Con.Close();
                MessageBox.Show("Leave Marked  !!");
                ShowData1();
                calculateLeaves();
            }
            else
            {
                Calculatebonus();
                int m = 0;
                textBox4.Text = m.ToString();
                Con.Open();
                string str = "insert into LeaveMod(ID,Name,Available_Leaves,Reason,Date,Address,Leave_Type) Values ('" + textBox3.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "')";
                cmd = new SqlCommand(str, Con);
                cmd.ExecuteNonQuery();
                cmd.Clone();
                Con.Close();
                MessageBox.Show("Leave Marked ! But it will deduct your Attendance Bonus !!");
                ShowData1();
              //  calculateLeaves();
                Calculatebonus();


            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Con.Open();
            string del = "Delete LeaveMod where ID='" + textBox3.Text + "' AND Date ='"+ dateTimePicker1.Text+"'";
            cmd = new SqlCommand(del, Con);
            cmd.ExecuteNonQuery();
            cmd.Clone();
            Con.Close();
            MessageBox.Show("Data Deleted !");
            ShowData1();
            calculateLeaves();
            textBox9.Text = 100.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

        }

        private void dataGridView1_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void df(object sender, EventArgs e)
        {

        }
        public void RetrieveAttendance()
        {
            Con.Open();
            string insert = "Select * from EmployeeAtt where ID = '" + textBox8.Text + "'  ";
            cmd = new SqlCommand(insert, Con);
            cmd.ExecuteNonQuery();
            cmd.Clone();
            Con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Con.Open();
            string insert = "insert into EmployeeAtt(ID,Name,Date,Time,Attendance) values ('" + textBox8.Text + "' , '" + textBox7.Text + "' ,'" + label13.Text + "','" + label14.Text + "','" + comboBox2.Text+ "' )";
            cmd = new SqlCommand(insert, Con);
            cmd.ExecuteNonQuery();
            cmd.Clone();
            Con.Close();
            MessageBox.Show("Attendance Marked  !!");

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void showleavestatus()
        {
            Con.Open();
            string st = "Select ID,Name,Reason,Date,Address,Leave_Type,Leave_Status from LeaveMod where ID='" + textBox3.Text + "'";
            cmd = new SqlCommand(st, Con);
            DataTable data = new DataTable();
            sd = cmd.ExecuteReader();
            data.Load(sd);
            dataGridView2.DataSource = data;
            Con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Con.Open();
            string st = "Select ID,Name,Reason,Date,Address,Leave_Type,Leave_Status from LeaveMod where ID='" + textBox3.Text + "'";
            cmd = new SqlCommand(st, Con);
            DataTable data = new DataTable();
            sd = cmd.ExecuteReader();
            data.Load(sd);
            dataGridView2.DataSource = data;
            Con.Close();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            LEaveModule.Visible = false;
            LeaveStatus.Visible = false;
            MarkAttendance.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LEaveModule.Visible = true;
            LeaveStatus.Visible = false;
            MarkAttendance.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           // LEaveModule.Visible = false;
            LeaveStatus.Visible = true;
            MarkAttendance.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
          //  LEaveModule.Visible = false;
          //  LeaveStatus.Visible = false;
            MarkAttendance.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            LEaveModule.Visible = false;
            LeaveStatus.Visible = false;
            MarkAttendance.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            LEaveModule.Visible = true;
            LeaveStatus.Visible = false;
            MarkAttendance.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
           // LEaveModule.Visible = false;
            LeaveStatus.Visible = true;
            MarkAttendance.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
           // LEaveModule.Visible = false;
           // LeaveStatus.Visible = false;
            MarkAttendance.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
