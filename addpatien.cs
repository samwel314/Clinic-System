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
    public partial class addpatien : Form
    {
        public addpatien()
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
                SqlCommand cmd = new SqlCommand("select pat from staticvalues where c_id = 1 ", conn);

                SqlDataReader d = cmd.ExecuteReader();

                while (d.Read())
                    Admin.ID = int.Parse(d[0].ToString()) + 1;
                Patient admin = new Patient();
                admin.fname = afna.Text;
                admin.email = aemail.Text;    
                admin.phone = aphone.Text;
                admin.lname = aLnmae.Text;
                admin.age = int.Parse(age.Text);

                conn.Close();
                conn.Open();
                cmd = new SqlCommand($"insert into Patient (id ,fname , lname , phone , email , age ,gender   ,dateofre  ) values" +
                    $" ({admin.Id} ,'{afna.Text}' , '{aLnmae.Text}' , '{aphone.Text}' , '{aemail.Text}',{int.Parse(age.Text)},  '{ge}'  , CURRENT_TIMESTAMP)", conn);
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

                radioButton1.Checked = false;
                age.Text = "";
                radioButton1.Checked = false;
                conn.Open();
                cmd.CommandText = "select pat from staticvalues where c_id = 2";
                Ticket.count = (int)cmd.ExecuteScalar() + 1 ;
                conn.Close();

                conn.Open();
                Ticket ticket = new Ticket();
                cmd.CommandText = $"insert into Ticket (id , a_id , a_name ,a_phone  ,  p_id , p_name ,p_phone , p_age , dateofre  ) values ({ticket.TicketId} , {login.admin.Id} , '{login.admin.fname + " " + login.admin.lname}','{login.admin.phone}' , {admin.Id} , '{admin.fname + " " + admin.lname}' , '{admin.phone}'  , {admin.age} ,  CURRENT_TIMESTAMP  ) ";
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                cmd.CommandText = $"update staticvalues set pat = {Ticket.count} where c_id = 2";
                cmd.ExecuteNonQuery();

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
