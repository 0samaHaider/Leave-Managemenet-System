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
    public partial class Admin : Form
    {


        readonly SqlConnection Con = new SqlConnection(@" Data Source = OSAMAHAIDER; Initial Catalog = DbProject; Integrated Security = True");
        SqlCommand cmd;
        SqlDataReader sd;
        public Admin()
        {
            InitializeComponent();
        }
        public void retrieve()
        {
            Con.Open();
            string str = "Select * from NewAccount";
            cmd = new SqlCommand(str, Con);
            DataTable data = new DataTable();
            sd = cmd.ExecuteReader();
            data.Load(sd);
            dataGridView1.DataSource = data;
            Con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            retrieve();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            string updates = "Update NewAccount  set Aprroval ='" + comboBox1.Text + "' where ID ='"+textBox1.Text+"' ";
            cmd = new SqlCommand(updates, Con);
            cmd.ExecuteNonQuery();
            cmd.Clone();
            Con.Close();
            MessageBox.Show("Updation Successfully  !");
            retrieve();
        }
        public void ShowData1()
        {
            Con.Open();
            string st = "Select ID,Name,Reason,Date,Address,Leave_Type,Leave_Status from LeaveMod";
            cmd = new SqlCommand(st, Con);
            DataTable data = new DataTable();
            sd = cmd.ExecuteReader();
            data.Load(sd);
            dataGridView2.DataSource = data;
            Con.Close();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            retrieve();
            EmployeeRecords.Visible = false;
            UserApproval.Visible = false;
            DailyAttendance.Visible = false;
            LeaveApproval.Visible = false;
            timer1.Start();



            // TODO: This line of code loads data into the 'dbProjectDataSet.NewAccount' table. You can move, or remove it, as needed.
            this.newAccountTableAdapter.Fill(this.dbProjectDataSet.NewAccount);
            ShowData1();
            label1.Text = DateTime.Now.ToLongDateString();


        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dateTimePicker1.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dateTimePicker1.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                Con.Open();
                string updates = "Update LeaveMod  set Leave_Status ='" + comboBox2.Text + "' ";
                cmd = new SqlCommand(updates, Con);
                cmd.ExecuteNonQuery();
                cmd.Clone();
                Con.Close();
                MessageBox.Show("Updation Successfully   !!");
                ShowData1();
            }
            catch
            {
                MessageBox.Show("Data is'nt Updated !");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Con.Open();
            string str = "Select * from NewAccount ";
            cmd = new SqlCommand(str, Con);
            DataTable data = new DataTable();
            sd = cmd.ExecuteReader();
            data.Load(sd);
            dataGridView3.DataSource = data;
            Con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Con.Open();
            string str = "Select * from LeaveMod ";
            cmd = new SqlCommand(str, Con);
            DataTable data = new DataTable();
            sd = cmd.ExecuteReader();
            data.Load(sd);
            dataGridView3.DataSource = data;
            Con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Con.Open();
            string str = "Select * from EmployeeAtt ";
            cmd = new SqlCommand(str, Con);
            DataTable data = new DataTable();
            sd = cmd.ExecuteReader();
            data.Load(sd);
            dataGridView3.DataSource = data;
            Con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Con.Open();
            string str = "Select * from EmployeeAtt where Date = '" + dateTimePicker2.Text + "'";
            cmd = new SqlCommand(str, Con);
            DataTable data = new DataTable();
            sd = cmd.ExecuteReader();
            data.Load(sd);
            dataGridView4.DataSource = data;
            Con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

        }

        private void df(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '{0}%'", textBox2.Text);

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            (dataGridView4.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '{0}%'", textBox3.Text);

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (dataGridView3.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '{0}%'", textBox4.Text);
            }
            catch
            {
                MessageBox.Show("No Data Found ", MessageBoxButtons.OKCancel.ToString());
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            EmployeeRecords.Visible = true;
            UserApproval.Visible = false;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            EmployeeRecords.Visible = false ;
            UserApproval.Visible = false;
            DailyAttendance.Visible = false;



        }

        private void button10_Click(object sender, EventArgs e)
        {
           // panel3.Visible = false;
            UserApproval.Visible = true ;
            DailyAttendance.Visible = false;



        }

        private void button11_Click(object sender, EventArgs e)
        {
            DailyAttendance.Visible = true;
            LeaveApproval.Visible = false;

        }

        private void button13_Click(object sender, EventArgs e)
        {
            LeaveApproval.Visible = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            EmployeeRecords.Visible = true;
            UserApproval.Visible = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            UserApproval.Visible = true;
            DailyAttendance.Visible = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            DailyAttendance.Visible = true;
            LeaveApproval.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            LeaveApproval.Visible = true;

        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();

            label11.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
