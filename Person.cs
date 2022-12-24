using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicMangementSystem
{
    internal class Person
    {
        protected int _id;
        string _fname;
        string _lname;
        string _description;
        string _phone;
        string _gender;
        string _email;
        int _age;
        string  _reTime;
        public Person()
        {
            _id = 0;
            _fname = "no_name";
            _lname = "no_name";
            _description = "no_description";
            _phone = "00000";
            _gender = "male";
            _email = "@Clinic.com";
            _age = 0;
            _reTime = "000"; 
        }
        public Person(string fname, string lname, int age, string description, string phone, string gender, string email)
        {
            _id = 0;
            _fname = fname;
            _lname = lname;
            _description = description;
            _phone = phone;
            _gender = gender;
            _email = email;
            _age = age;
            _reTime = "000";
        }
        public int Id { get { return _id; }set { _id = value; } }
        public string fname { get { return _fname; } set { _fname = value; } }
        public string lname { get { return _lname; } set { _lname = value; } }

        public int age { get { return _age; } set { _age = value; } }

        public string  ReTime { get { return _reTime; } set { _reTime = value; } }

        public string email { get { return _email; } set { _email = value; } }

        public string gender { get { return _gender; } set { _gender = value; } }

        public string phone { get { return _phone; } set { _phone = value; } }  

        public string description { get { return _description; } set { _description = value; } }   

    }
    
}
