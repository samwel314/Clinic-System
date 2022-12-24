using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClinicMangementSystem
{
    internal class Admin : Person
    {

        public static int ID = 101;
        string _password;
        Doctor _doctor; 
        int _ticketNumber; 
        public Admin() : base()
        {
            _id = ID;
            _doctor = new Doctor(); 
            ID++;
            _password = "0000";
            _ticketNumber = 0;
        }
        public Admin(Doctor d, string fname, string lname, int age, string description, string phone, string gender, string email, string password) : base(fname, lname, age, description, phone, gender, email)
        {
            _id = ID;
            ID++;
            _password = password;
            _doctor = d;
            _ticketNumber = 0; 
        }
        public string password { get { return _password; } set { _password = value; } }

        public int D_id { get { return _doctor.D_id; } }
        public int TicketNumber { get { return _ticketNumber; } }
        public void AddTicket() => _ticketNumber++;
        public bool Is_Admin(Admin  A)
        {
            if (this.phone == A.phone && this.password ==A.password)
                return true;
            else
                return false;
        }

    }
}
