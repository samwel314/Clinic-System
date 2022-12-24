using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicMangementSystem
{
    internal class Patient : Person 
    {
       static int ID = 162020;
        int _ticketNumber;

        public Patient() : base()
        {
            _id = ID;
            ID++;
            _ticketNumber = 0;
        }
        public Patient(string fname, string lname, int age, string description, string phone, string gender, string email) : base(fname, lname, age, description, phone, gender, email)
        {
            _id = ID;
            ID++;
            _ticketNumber = 0; 
        }
        
        public bool Is_Patient(Patient P)
        {
            if (this.phone == P.phone && this.fname == P.fname)
                return true;
            else
                return false; 
        }
        public void AddTicket() => _ticketNumber++;
        public int TicketNumber { get { return _ticketNumber; } }
    }
}
