use Teaching_ITI_D3

Create table Instructor(
ID int primary key identity,
Fname varchar(20),
Lname varchar(20),
BD datetime,
overtime float unique,
salary float,
hiredate datetime,
address varchar(50),
age as (year(getdate())-year(BD)),
Netsalary as (salary+overtime),

constraint c1 check(salary between 1000 and 5000),
constraint c2 check(address='cairo' or address='alex')

);
drop table Instructor
drop table Teach


create default def2 as getdate()
sp_bindefault def2,'Instructor.hiredate',

create default def1 as 3000
sp_bindefault def1,'Instructor.salary',




create table Course(
CID int primary key identity,
Cname varchar(20),
Duration time unique
);

create table Lab(
LID int identity,
Location varchar(50),
capacity int,
CID int,
Foreign key (CID) References Course(CID) on delete cascade on update cascade,

Primary key (LID,CID),

constraint c7 check(capacity<20)

);

create table Teach(
CID int,
ID int,
Foreign key (CID) references Course(CID) on delete cascade on update cascade,
Foreign key (ID) references Instructor(ID) on delete cascade on update cascade,
Primary key (CID,ID)
);
