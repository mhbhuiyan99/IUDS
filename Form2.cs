using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IUDS
{
    public partial class Form2 : Form
    {
        public static Form2 Instance;
        public Form2()
        {
            InitializeComponent();
            Instance = this;
        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string a = Form1.Instance?.t1?.Text ?? "null";
                string b = Form1.Instance?.t2?.Text ?? "null";

                if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
                {
                    MessageBox.Show("One or both text fields are empty.");
                    return;
                }

                dataGridView1.Rows.Add(a, b);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

    }
}
