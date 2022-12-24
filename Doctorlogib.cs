using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ClinicMangementSystem
{
    public partial class Doctorlogib : Form
    {
        public Doctorlogib()
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (!dataGridView1.Visible)
                dataGridView1.Visible = true;
            else
                dataGridView1.Visible = false;

            string constring = "data source=.; Database=ClinicDb; Integrated Security=true";
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();

            SqlDataAdapter dt = new SqlDataAdapter("select *from Admin", conn);
            DataTable  dase = new DataTable();
            dt.Fill(dase );
            dataGridView1.DataSource = dase; 
            conn.Close();   
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (!dataGridView2.Visible)
                dataGridView2.Visible = true;
            else
                dataGridView2.Visible = false;

            string constring = "data source=.; Database=ClinicDb; Integrated Security=true";
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();

            SqlDataAdapter dt = new SqlDataAdapter("select *from Patient", conn);
            DataTable dase = new DataTable();
            dt.Fill(dase);
            dataGridView2.DataSource = dase;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cfname.Text != "" && clname.Text != "" && cmail.Text != "" && chngepass.Text != "")
            {

                string constring = "data source=.; Database=ClinicDb; Integrated Security=true";
                SqlConnection conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand($"update Doctor set fname = '{cfname.Text}' , lname = '{clname.Text}' , phone = '{cphone.Text}' , email = '{cmail.Text}' , password = '{chngepass.Text}'where id = {int.Parse(cid.Text)} ", conn);
                cmd.ExecuteNonQuery();
                login.doctor.fname = cfname.Text;
                login.doctor.lname = clname.Text;
                login.doctor.password = chngepass.Text;
                login.doctor.email = cmail.Text;
                login.doctor.phone = cphone.Text;
              
                MessageBox.Show("Done");
                conn.Close();
            }
            else
                MessageBox.Show("Text Box is Empty Enter Data");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddAdmin admin = new AddAdmin();
            admin.Show(); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Deletead deletead = new Deletead();
            deletead.Show();        


        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close(); 
        }
    }
}
