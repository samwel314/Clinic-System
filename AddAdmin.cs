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
    public partial class AddAdmin : Form
    {
        public AddAdmin()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
          
            if (afna.Text != "" && aLnmae.Text != "" && afna.Text != "" && aphone.Text != "" && aemail.Text != "" && age.Text != "")
            {
                string ge;

                if (radioButton1.Checked == true)
                    ge = radioButton1.Text;
                else
                    ge = radioButton2.Text;
                string constring = "data source=.; Database=ClinicDb; Integrated Security=true";
                SqlConnection conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select adm from staticvalues where c_id = 1 ", conn);

                SqlDataReader d = cmd.ExecuteReader();

                while (d.Read())
                    Admin.ID = int.Parse(d[0].ToString()) + 1;
                Admin admin = new Admin();
                conn.Close();
                conn.Open();
                cmd = new SqlCommand($"insert into Admin (id ,fname , lname , phone , email , age ,gender , password   ,   D_id , D_name ,dateofre  ) values" +
                    $" ({admin.Id} ,'{afna.Text}' , '{aLnmae.Text}' , '{aphone.Text}' , '{aemail.Text}',{int.Parse(age.Text)},  '{ge}', '{apass.Text}'  , {login.doctor.Id} ,'{login.doctor.fname + " " + login.doctor.lname}'  , CURRENT_TIMESTAMP)", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                cmd.CommandText = $"update staticvalues set adm = {admin.Id} where c_id = 1";
                cmd.ExecuteNonQuery();
                conn.Close();
                afna.Text = "";
                aLnmae.Text = "";
                aphone.Text = "";
                aemail.Text = "";
                apass.Text = "";
                radioButton1.Checked = false;
                age.Text = "";
                radioButton1.Checked = false;

                MessageBox.Show("Done");
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
