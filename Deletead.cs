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

namespace ClinicMangementSystem
{
    public partial class Deletead : Form
    {
        public Deletead()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text !="")
            {
                try
                {
                    string constring = "data source=.; Database=ClinicDb; Integrated Security=true";
                    SqlConnection conn = new SqlConnection(constring);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"delete from Admin where id = {int.Parse(textBox1.Text)}  ", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Done");
                }
                catch(Exception ec)
                {
                    MessageBox.Show("id not found ");
                }
             
            }
            else
            {
                MessageBox.Show("Some text box is Empty");
            }
          

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();   
        }
    }
}
