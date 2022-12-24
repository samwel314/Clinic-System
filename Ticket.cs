using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicMangementSystem
{
    internal class Ticket
    {
        // pname , aname , pphone , aphone  , page  dateof notes   , pdescription
        public static int count = 1; 
        int _ticketId;
        Admin _admin;
        Patient _patient;
        string _note; 
        DateTime _dateoftake;
        public Ticket()
        {
            _admin = new Admin(); 
            _patient = new Patient();    
            _ticketId = count;
            count++;
            _note = "no_note"; 
            _dateoftake = DateTime.Now;
        }
        public Ticket(Admin admin ,  Patient patient  )
        {
            _ticketId = count;
            count++;
            _note = "no_note";
            _admin = admin;
            _patient = patient;
            _dateoftake = DateTime.Now;
        }
        public int TicketId { get { return _ticketId; } }
        public string Aname { get { return _admin.fname + " " + _admin.lname ; } }
        public string Aphone { get { return _admin.phone; } }

        public string Pname { get { return _patient.fname + " " + _patient.lname; } }
        public string Pphone { get { return _patient.phone; } }
        public int Page { get { return _patient.age; } }
        public string note { get { return _note; } set{ note = value; } }
        public string pdescription { get { return _patient.description; } set{ _patient.description = value; } }
        public DateTime Dateoftake { get { return _dateoftake; } }

    }
}
