namespace ClinicMangementSystem
{
    using System.Data.SqlClient; 
    public partial class login : Form
    {
        internal static Doctor doctor = new Doctor();
        internal static Admin admin = new Admin();
        public login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!panel1.Visible)
                panel1.Visible = true; 
            else
                panel1.Visible = false; 
        }
        bool refromDoctor ()
        {
            bool checkdo = false;
            string constring = "data source=.; Database=ClinicDb; Integrated Security=true";
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Doctor ", conn);

            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                String phone = Phonetext.Text;
                string password = passwordtext.Text;
                string rephone = read[3].ToString();
                string repass = read[10].ToString();
                if (repass.Equals(password) && rephone.Equals(phone))
                {
                    doctor.fname = read[1].ToString();
                    doctor.lname = read[2].ToString();
                    doctor.phone = phone;
                    doctor.email = read[4].ToString();
                    doctor.gender = read[5].ToString();
                    doctor.age = int.Parse(read[6].ToString());
                    doctor.ReTime = Convert.ToString(read[7]);
                    doctor.password = password;
                    doctor.description = read[11].ToString();
                    checkdo = true;
                    conn.Close();

                    break;
                }
            }
            return checkdo; 
        }

        bool refromadmin()
        {
            bool checkad = false;
            string constring = "data source=.; Database=ClinicDb; Integrated Security=true";
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Admin ", conn);

            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                String phone = Phonetext.Text;
                string password = passwordtext.Text;
                string rephone = read[3].ToString();
                string repass = read[11].ToString();
                if (repass.Equals(password) && rephone.Equals(phone))
                {
                    admin.fname = read[1].ToString();
                    admin.lname = read[2].ToString();
                    admin.phone = phone;
                    admin.email = read[4].ToString();
                    admin.gender = read[5].ToString();
                    admin.age = int.Parse(read[6].ToString());
                    admin.ReTime = Convert.ToString(read[7]);
                    admin.password = password;
                    admin.description = read[12].ToString();
                    checkad = true;
                    conn.Close();
             
                    break;
                }
            
            }
            return checkad;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            
            if (Phonetext.Text != "" && passwordtext.Text != "")
            {
                if (refromDoctor())
                {
                    Doctorlogib doctorlogib = new Doctorlogib();
                    doctorlogib.cid.Text = Convert.ToString(doctor.D_id);
                    doctorlogib.cfname.Text = doctor.fname;
                    doctorlogib.clname.Text = doctor.lname;
                    doctorlogib.cphone.Text = doctor.phone;
                    doctorlogib.cmail.Text = doctor.email;
                    doctorlogib.chngepass.Text = doctor.password;
                    doctorlogib.Show();
                }
                else if (refromadmin())
                {
                    string constring = "data source=.; Database=ClinicDb; Integrated Security=true";
                    SqlConnection conn = new SqlConnection(constring);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"select id from Admin where phone = {Phonetext.Text} ", conn);
                    // error her ..
                    admin.Id = (int)cmd.ExecuteScalar();

                   Adminlogincs adminlogincs = new Adminlogincs();
                    adminlogincs.cid.Text = Convert.ToString(admin.Id);
                    adminlogincs.cfname.Text = admin.fname;
                    adminlogincs.clname.Text = admin.lname;
                    adminlogincs.cphone.Text = admin.phone;
                    adminlogincs.cmail.Text = admin.email;
                    adminlogincs.chngepass.Text = admin.password;
                    adminlogincs.Show();

                }
                else
                    MessageBox.Show("Phone or password not correct .."); 


            }
            else
            {
                MessageBox.Show("Text Box is Empty Enter Data"); 
            }
        
      



        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}