use Company_SD
//Q1
select Dnum , Dname , Fname from Departments D inner join Employee E on E.SSN= D.MGRSSN 


//Q2 
select Dname , Pname from Departments D inner join Project P on D.Dnum = P.Dnum


//Q3
select Fname , D.* from Employee E inner join dbo.Dependent D on D.ESSN= E.SSN


//Q4
select Pnumber , Pname , Plocation from Project where City='Cairo' OR City='Alex'


//Q5
select * from Project where Pname Like 'a%'


//Q6
select Fname , Lname from Employee Where Dno=30 AND Salary between 1000 and 2000


//Q7
select Fname from Employee E inner join Works_for W on E.SSN=W.ESSn inner join Project P on W.Pno= P.Pnumber Where E.Dno=10 AND W.Hours >=10 AND P.Pname='AL Rabwah'


//Q8
select emp.Fname , Supervisor.Fname, Supervisor.Lname
from Employee emp , Employee Supervisor Where Supervisor.SSN= emp.Superssn AND Supervisor.Fname='Kamel' AND Supervisor.Lname='Mohamed'


//Q9
select Fname , Lname , Pname from Employee E inner join Works_for W on E.SSN=W.ESSn inner join Project P on P.Pnumber= W.Pno order by P.Pname


//Q10
select P.Pnumber ,D.Dname, E.Lname ,E.Address, E.Bdate from Project P inner join Departments D on P.Dnum= D.Dnum inner join Employee E on E.SSN =D.MGRSSN
Where P.City='Cairo'

//Q11
select E.* from Employee E inner join Departments D on D.MGRSSN=E.SSN 


//Q12
select E.* , D.* from Employee E left outer join Dependent D on E.SSN =D.ESSN 

//Q13
Insert Into Employee Values('ahmed','hasan',102672,1965-01-01,'Cairo','male',3000,112233,30 )

//Q14
Insert Into Employee Values('mahmoud','ayman',102660,1975-01-01,'Cairo','male',30 )

//Q15
update
Employee set Salary=Salary + 0.20*Salary Where SSN=102672