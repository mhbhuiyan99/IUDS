using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IUDS
{
    public partial class Form1 : Form
    {
        private string connectionString = (@"Data Source=DESKTOP-3SNGNAJ\SQLEXPRESS;Initial Catalog=C#DB;Integrated Security=True");
        public static Form1 Instance;
        public TextBox t1, t2;
        public Form1()
        {
            InitializeComponent();
            Instance = this;
            t1 = textBox1;
            t2 = textBox2;
        }
        public void show()
        {
            dataGridView1.Rows.Clear();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("select * from IUDS", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["ID"], reader["Namee"], reader["Age"], reader["Dept"], reader["Gender"]);
                }
                reader.Close();
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        String gender, dept;
        public void dept_check()
        {
            if (radioButton1.Checked)
            {
                dept = "cse";
            }
            else if (radioButton2.Checked)
            {
                dept = "ict";
            }
            else if (radioButton3.Checked)
            {
                dept = "te";
            }
            else dept = "Null";
        }
        public void genderCheck()
        {
            if (radioButton4.Checked)
            {
                gender = "Male";
            }
            else if (radioButton5.Checked)
            {
                gender = "Female";
            }
            else gender = "Null";
        }

        public void insert()
        {
            try
            {
                dataGridView1.Rows.Clear();
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                Int32 a = Convert.ToInt32(textBox1.Text);
                String b = textBox2.Text;
                String c = textBox3.Text;
                dept_check();
                String d = dept;
                genderCheck();
                String e = gender;
                SqlCommand command = new SqlCommand("insert into IUDS values ('" + a + "','" + b + "','" + c + "','" + d + "','" + e + "')", connection);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    dataGridView1.Rows.Add(reader["ID"], reader["Namee"],reader["Age"], reader["Dept"], reader["Gender"]);
                }
                show();
                reader.Close();
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void update()
        {
            try
            {
                dataGridView1.Rows.Clear();
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                Int32 a = Convert.ToInt32(textBox1.Text);
                String b = textBox2.Text;
                String c = textBox3.Text;
                dept_check();
                String d = dept;
                genderCheck();
                String e = gender;
                SqlCommand command = new SqlCommand("update IUDS set ID ='" + a + "',Namee='" + b + "',Age='" + c + "',Dept='" + d + "',Gender='" + e + "' where ID = '" + a + "'", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["ID"], reader["Namee "], reader["Age"], reader["Dept"], reader["Gender"]);
                }
                show();
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            insert();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete();
        }

        public void delete()
        {
            try
            {
                dataGridView1.Rows.Clear();
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                Int32 a = Convert.ToInt32(textBox1.Text);
                String b = textBox2.Text;
                String c = textBox3.Text;
                dept_check();
                String d = dept;
                genderCheck();
                String e = gender;
                SqlCommand command = new SqlCommand("delete from IUDS where id='"+a+"'",connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["ID"], reader["Namee"], reader["Age"], reader["Dept"], reader["Gender"]);
                }
                show();
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
