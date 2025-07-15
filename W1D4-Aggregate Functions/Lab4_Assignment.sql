use Company_SD

//Q 1.1
select D.Dependent_name , D.Sex from Dependent D 
inner join Employee E on E.SSN=D.ESSN
where D.Sex='female' AND E.Sex='female' 

UNION

select D.Dependent_name , D.Sex from Dependent D
inner join Employee E on E.SSN=D.ESSN
where E.Sex='male' AND D.Sex='male'

//Q2
select P.Pname , sum(W.Hours)
from Project P inner join Works_for W on P.Pnumber=W.Pno 
inner join Employee E on E.SSN= W.ESSn
group by P.Pname

//Q3
select D.* from Departments D inner join Employee E on D.Dnum=E.Dno 
Where E.SSN= (select MIN(E.SSN) from Employee E )

//Q4
select D.Dname, MAX(E.Salary),MIN(E.Salary),AVG(E.Salary) from Departments D inner join Employee E on D.Dnum=E.Dno
group by D.Dname

//Q5
select E.fname,E.lname from Employee E inner join Departments D on E.SSN=D.MGRSSN 
where E.SSN Not in (select Dependent.ESSN from Dependent)

//Q6
select D.Dname, D.Dnum , COUNT(E.SSN) from Departments D inner join Employee E on D.Dnum=E.Dno
group by D.Dname , D.Dnum
having AVG(E.Salary) < (select AVG(Salary) from Employee)

//Q7
select E.Fname, E.Lname , P.Pname from Employee E inner join Works_for W on E.SSN=W.ESSn inner join Project P on P.Pnumber=W.Pno
order by P.Dnum , E.Lname , E.Fname

//Q8
select E.Salary from Employee E where E.Salary In (select Top 2 Salary from Employee order by Salary Desc)


//Q9
select E.Fname, E.Lname from Employee E where CONCAT(E.Fname, ' ', E.Lname) In (select Dependent.Dependent_name from Dependent)

//Q10
select E.SSN , E.Fname , E.Lname from Employee E where Exists(select 1 from Dependent D where D.ESSN=E.SSN)

//Q11
Insert into Departments Values('DEPT IT', 100, 112233,1-11-2006 )

//Q12
update Departments set MGRSSN=968574 where Dnum=100
update Departments set MGRSSN=102672 where Dnum=20
update Employee set Superssn=102672 where SSN=321654

//Q13   
delete from Works_for where ESSn=223344 --done
delete from Dependent where ESSN=223344 --done
delete from Works_for where Pno=100 OR Pno=200 OR Pno=300 --done
delete from Project where Dnum=10 --done
update Departments set MGRSSN=102672 where MGRSSN=223344--done
update Employee set Superssn=102672 where Superssn=223344--done
delete from Employee where SSN=223344--done

//Q14

update Employee set Salary=Salary+0.30*Salary where SSN In(select W.ESSn from Works_for W  inner join Project P on W.Pno=P.Pnumber where Pname='Al Rabwah')



