create table Doctor (
id int primary key , 
fname varchar(25) not null , 
lname varchar(25) not null , 
phone varchar (11) not null , 
email varchar(80) not null , 
gender varchar (7) not null ,  
age int , 
dateofre DateTime not null , 
numberPatient int , 
numberAdmin int , 
password varchar(20) , 
description varchar(255) , 
)


create table Admin (
id int primary key , 
fname varchar(25) not null , 
lname varchar(25) not null , 
phone varchar (11) not null , 
email varchar(80) not null , 
gender varchar (7) not null ,  
age int , 
dateofre DateTime not null , 
ticketNumber int , 
D_name varchar(25) not null ,
D_id int foreign  key references Doctor (id) , 
password varchar(20) , 
description varchar(255) , 
)


create table Patient (
id int primary key , 
fname varchar(25) not null , 
lname varchar(25) not null , 
phone varchar (11) not null , 
email varchar(80) not null , 
gender varchar (7) not null ,  
age int , 
dateofre DateTime not null , 
ticketNumber int , 
description varchar(255) , 
)

create table Ticket(
id int primary key , 
a_id int foreign  key references Admin (id) , 
a_name varchar(25) not null , 
a_phone varchar (11) not null  , 
p_id int foreign  key references Patient (id) , 
p_name varchar(25) not null , 
p_phone varchar (11) not null ,
p_age int , 
p_description varchar(255) , 
notes varchar(255) , 
dateofre DateTime not null , 
)


create table staticvalues(
doc int , 
pat int , 
adm int , 
)


/*



        int _id;
        string _fname;
        string _lname;
        string _description;
        string _phone;
        string _gender;
        string _email;
        int _age;
        DateTime _reTime;
        string _password;
        int _numberPatient;
        int _numberAdmin; 
*/