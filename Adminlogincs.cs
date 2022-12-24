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
    public partial class Adminlogincs : Form
    {
        public Adminlogincs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!groupBox1.Visible)
                groupBox1.Visible = true;
            else
                groupBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cfname.Text != "" && clname.Text != "" && cmail.Text != "" && chngepass.Text != "")
            {

                string constring = "data source=.; Database=ClinicDb; Integrated Security=true";
                SqlConnection conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand($"update Admin set fname = '{cfname.Text}' , lname = '{clname.Text}' , phone = '{cphone.Text}' , email = '{cmail.Text}' , password = '{chngepass.Text}'where id = {int.Parse(cid.Text)} ", conn);
                cmd.ExecuteNonQuery();
                login.admin.fname = cfname.Text;
                login.admin.lname = clname.Text;
                login.admin.password = chngepass.Text;
                login.admin.email = cmail.Text;
                login.admin.phone = cphone.Text;
            
                MessageBox.Show("Done");
                conn.Close();
            }
            else
                MessageBox.Show("Text Box is Empty Enter Data");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!dataGridView1.Visible)
                dataGridView1.Visible = true;
            else
                dataGridView1.Visible = false;

            string constring = "data source=.; Database=ClinicDb; Integrated Security=true";
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();

            SqlDataAdapter dt = new SqlDataAdapter("select *from Ticket", conn);
            DataTable dase = new DataTable();
            dt.Fill(dase);
            dataGridView1.DataSource = dase;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addpatien aAdpatien = new addpatien();
            aAdpatien.Show(); 
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
