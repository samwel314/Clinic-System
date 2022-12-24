using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicMangementSystem
{
    internal class Doctor : Person
    {
        static int ID = 1;
        string _password;
        int _numberPatient;
        int _numberAdmin; 
        public Doctor() : base()
        {
            _id = ID;
            ID++;
            _password = "0000";
            _numberPatient = 0;
            _numberAdmin = 0; 
        }
        public Doctor(string fname, string lname, int age, string description, string phone, string gender, string email , string password) :base( fname,  lname,  age,  description,  phone,  gender,  email)
        {
            _id=ID;
            ID++; 
            _password = password;
            _numberPatient = 0;
            _numberAdmin = 0;
        }
        public string password { get { return _password; } set { _password = value; } }
        public int D_id { get { return _id; } }
        public bool Is_Doctor (Doctor D)
        {
            if (this.phone == D.phone  && this.password == D.password)
                return true;
            else
               return false;             
        }
        public int NumberofPatient { get { return _numberPatient; } }
        public void Add1PatientNumber () => _numberPatient++;   
        public void Remove1PatientNumber () => _numberPatient--;
        public int NumberofAdmin { get { return _numberAdmin; } }
        public void Add1AdminNumber() => _numberAdmin ++;
        public void Remove1AdmintNumber() => _numberAdmin --;
    }
}
