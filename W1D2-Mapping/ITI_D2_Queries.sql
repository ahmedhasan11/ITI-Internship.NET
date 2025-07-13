USE Company_SD
select * From Employee

USE Company_SD
select Fname,Lname,Salary,Dno From Employee

USE Company_SD
select Pname, Plocation,Dnum from Project

USE Company_SD
select Fname , Lname , Salary*0.10 AS annualComession from Employee

USE Company_SD
select SSN , Fname from Employee where Salary >1000 


USE Company_SD
select SSN , Fname from Employee where Salary*12 >10000

USE Company_SD
select Fname , Lname , Salary from Employee where Sex= 'female'

USE Company_SD
select Dnum, Dname from Departments where MGRSSN =968574 

USE Company_SD
select Pnumber, Pname,Plocation from Project where Dnum= 10
