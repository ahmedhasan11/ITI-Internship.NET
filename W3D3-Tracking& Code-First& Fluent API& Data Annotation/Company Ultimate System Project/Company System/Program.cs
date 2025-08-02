using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Company_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
			var context = new CompanyContext();
			while (true)
			{
				Console.WriteLine("1-Add");
				Console.WriteLine("2-Display");
				Console.WriteLine("3-Edit");
				Console.WriteLine("4-Delete");
				string option = Console.ReadLine();
				switch (option)
				{
					case "1": //ADD
						Console.WriteLine("1-Department");
						Console.WriteLine("2-Employee");
						Console.WriteLine("3-Project");
						string selection = Console.ReadLine();
						switch (selection)
						{
							case "1"://ADD DEPARTMENT
								Department dept = new Department();
								Console.WriteLine("enter dept name");
								dept.Department_Name = Console.ReadLine();
								context.Department.Add(dept);
								context.SaveChanges();
								break;//ADD DEPARTMENT
							case "2"://ADD EMPLOYEE
								Employee emp = new Employee();
								Console.WriteLine("enter emp first-name");
								emp.Employee_Firstname = Console.ReadLine();
								Console.WriteLine("enter emp last-name");
								emp.Employee_Lastname = Console.ReadLine();
								Console.WriteLine("enter emp dept_id");
								emp.DepartmentID = int.Parse(Console.ReadLine());
								context.Employee.Add(emp);
								context.SaveChanges();
								break;//ADD EMPLOYEE
							case "3"://ADD PROJECT
								Project project = new Project();
								project.Project_Name = Console.ReadLine();
								project.StartDate = DateOnly.Parse(Console.ReadLine());
								project.EndDate = DateOnly.Parse(Console.ReadLine());
								context.Projects.Add(project);
								context.SaveChanges();
								break;//ADD PROJECT
						}
						break; //ADD--DONE

					case "2":
						Console.WriteLine("1-Employee Data");
						Console.WriteLine("2-Department Data");
						Console.WriteLine("3-Project Data");
						string selected = Console.ReadLine();
						switch (selected)
						{
							case "1":
								foreach (var Emp in context.Employee.Include(e => e.Department).Include(e => e.Emp_proj).ThenInclude(ep => ep.Project))
								{
									Console.WriteLine($"Emp_ID:{Emp.EmployeeID}");
									Console.WriteLine($"Emp_Firstname:{Emp.Employee_Firstname}");
									Console.WriteLine($"Emp_Lastname:{Emp.Employee_Lastname}");
									Console.WriteLine($"Emp_DeptID:{Emp.Department.DepartmentID}");
									Console.WriteLine($"Emp_DeptName:{Emp.Department.Department_Name}");
									foreach (var project in Emp.Emp_proj)
									{
										Console.WriteLine($"Project_ID{project.Project.ProjectID}");
										Console.WriteLine($"Project_Name{project.Project.Project_Name}");

									}
								}
								break;//DISPLAY EMPLOYEE DATA
							case "2":
								foreach (var Department in context.Department.Include(d => d.Employees))
								{
									Console.WriteLine($"DepartmentID:{Department.DepartmentID}");
									Console.WriteLine($"DepartmentName:{Department.Department_Name}");
									foreach (var Emp in Department.Employees)
									{
										Console.WriteLine($"EmpID:{Emp.EmployeeID}");
										Console.WriteLine($"Emp_Fname:{Emp.Employee_Firstname}");
										Console.WriteLine($"Emp_Lname:{Emp.Employee_Lastname}");
									}

								}
								break;//DISPLAY DEPARTMENT DATA
							case "3":
								foreach (var project in context.Projects.Include(p => p.Emp_proj).ThenInclude(ep => ep.Employee))
								{
									Console.WriteLine($"{project.ProjectID}");
									Console.WriteLine($"{project.Project_Name}");
									foreach (var Emp in project.Emp_proj)
									{
										Console.WriteLine($"{Emp.Employee.EmployeeID}");
										Console.WriteLine($"{Emp.Employee.Employee_Firstname}");
										Console.WriteLine($"{Emp.Employee.Employee_Lastname}");
									}
								}
								break;//DISPLAY PROJECT DATA
						}
						break; //DISPLAY--DONE

					case "3": //EDIT--DONE
						Console.WriteLine("1-Employee");
						Console.WriteLine("2-Department");
						Console.WriteLine("3-Project");
						string edit_selection = Console.ReadLine();
						switch (edit_selection)
						{
							case "1"://EDIT Employee DATA 
								Console.WriteLine("1.1-Employee Data");
								Console.WriteLine("1.2-Assign Employees To Department");
								Console.WriteLine("1.3-Assign Employee to Project");
								Console.WriteLine("1.4-Remove Employee from project");
								string selected_option = Console.ReadLine();
								switch (selected_option)
								{
									case "1.1":
										//EDIT employee data
										Console.WriteLine("enter employee id:");
										Employee employee = new Employee();
										employee.EmployeeID = int.Parse(Console.ReadLine());
										var EMP = context.Employee.Include(e => e.Department).Include(ep => ep.Emp_proj).ThenInclude(ep => ep.Project).Where(e => e.EmployeeID == employee.EmployeeID).FirstOrDefault();
										if (EMP != null)
										{
											Console.WriteLine($"Emp_ID:{EMP.EmployeeID}");
											Console.WriteLine($"Emp_Firstname:{EMP.Employee_Firstname}");
											Console.WriteLine($"Emp_Lastname:{EMP.Employee_Lastname}");
											Console.WriteLine($"Emp_DeptID:{EMP.Department.DepartmentID}");
											Console.WriteLine($"Emp_DeptName:{EMP.Department.Department_Name}");
											foreach (var projectt in EMP.Emp_proj)
											{
												Console.WriteLine($"Project_ID{projectt.Project.ProjectID}");
												Console.WriteLine($"Project_Name{projectt.Project.Project_Name}");

											}

										}
										else
										{
											Console.WriteLine("emp not found");
										}

										Console.WriteLine("select option to edit");
										Console.WriteLine("1-First Name");
										Console.WriteLine("2-Last Name");
										string emp_data_option = Console.ReadLine();

										switch (emp_data_option)
										{
											case "1":
												Console.WriteLine("enter the new first name");
												EMP.Employee_Firstname = Console.ReadLine();
												context.SaveChanges();
												Console.WriteLine("employee first name changed successfully");
												break;

											case "2":
												Console.WriteLine("enter the new Last name");

												EMP.Employee_Lastname = Console.ReadLine();

												context.SaveChanges();
												Console.WriteLine("employee Last name changed successfully");
												break;
										}

										break;
									case "1.2":
										Console.WriteLine("enter employee id:");
										Employee employee2 = new Employee();
										employee2.EmployeeID = int.Parse(Console.ReadLine());
										var EMP2 = context.Employee.Include(e => e.Department).Include(ep => ep.Emp_proj).ThenInclude(ep => ep.Project).Where(e => e.EmployeeID == employee2.EmployeeID).FirstOrDefault();
										if (EMP2 != null)
										{
											Console.WriteLine("enter department_ID which you want to assign the employee");
											int DepartmentID = int.Parse(Console.ReadLine());
											var dept = context.Department.Where(d => d.DepartmentID == DepartmentID).FirstOrDefault();
											if (dept != null)
											{
												EMP2.DepartmentID = dept.DepartmentID;
												context.SaveChanges();
												Console.WriteLine("employee assigned to department successfully");
											}
											else
											{
												Console.WriteLine("department not found");
											}
										}
										else
										{
											Console.WriteLine("employee not found");
										}
										break;
									case "1.3":
										Console.WriteLine("enter employee id");
										int EmployeeID = int.Parse(Console.ReadLine());
										var EMP3 = context.Employee.Include(e => e.Department).Include(e => e.Emp_proj).ThenInclude(ep => ep.Project).Where(e => e.EmployeeID == EmployeeID).FirstOrDefault();
										if (EMP3 != null)
										{
											Console.WriteLine("enter project id which you want to assign the employee");
											int projectID = int.Parse(Console.ReadLine());
											var project = context.Projects.Where(p => p.ProjectID == projectID).FirstOrDefault();
											bool is_Assigned = context.Employee_Projects.Any(ep => ep.EmployeeID == EMP3.EmployeeID && ep.ProjectID == project.ProjectID);
											if (!is_Assigned)
											{
												if (project != null)
												{
													var Emp_proj = new Employee_Project()
													{
														EmployeeID = EMP3.EmployeeID,
														ProjectID = project.ProjectID
													};
													context.Employee_Projects.Add(Emp_proj);
													context.SaveChanges();
													Console.WriteLine("successfully linked employee to project");
												}
												else
												{
													Console.WriteLine("project not found");
												}
											}
											else
											{
												Console.WriteLine("this project is assigned already to that employee");
											}

										}
										else
										{
											Console.WriteLine("employee not found");
										}

										//assign emp to proj
										break;
									case "1.4":
										Console.WriteLine("enter id of the employee you want to remove from project");
										int employeeID = int.Parse(Console.ReadLine());
										Console.WriteLine("enter the project id you want to remove the employee from");
										int project2ID = int.Parse(Console.ReadLine());
										bool isthereassigned = context.Employee_Projects.Any(ep => ep.EmployeeID == employeeID && ep.ProjectID == project2ID);

										if (isthereassigned)
										{
											var empproj = context.Employee_Projects.Where(ep => ep.EmployeeID == employeeID && ep.ProjectID == project2ID).FirstOrDefault();
											context.Employee_Projects.Remove(empproj);
											context.SaveChanges();
										}
										else
										{
											Console.WriteLine("there is no already assign between them");
										}

										break;
								}
								break; //EDIT Employee DATA 
							case "2"://EDIT Department DATA
								Console.WriteLine("2.1-Department Data");
								Console.WriteLine("2.2-Assign Employees To Department");
								string options = Console.ReadLine();
								switch (options)
								{
									case "2.1":
										//edit dept data
										Console.WriteLine("enter department ID:");
										int departmentid = int.Parse(Console.ReadLine());
										var dept = context.Department.Include(d => d.Employees).Where(d => d.DepartmentID == departmentid).FirstOrDefault();
										if (dept != null)
										{
											Console.WriteLine($"DepartmentID:{dept.DepartmentID}");
											Console.WriteLine($"DepartmentName:{dept.Department_Name}");
											foreach (var Empss in dept.Employees)
											{
												Console.WriteLine($"EmpID:{Empss.EmployeeID}");
												Console.WriteLine($"Emp_Fname:{Empss.Employee_Firstname}");
												Console.WriteLine($"Emp_Lname:{Empss.Employee_Lastname}");
											}
											Console.WriteLine("enter new name of the department");
											string deptname = Console.ReadLine();
											dept.Department_Name = deptname;
											context.SaveChanges();
											Console.WriteLine("department name changed successfully");
										}
										else
										{
											Console.WriteLine("department not found");
										}

										break;
									case "2.2":
										Console.WriteLine("enter department id you want to assign the employees in");
										int dept2id = int.Parse(Console.ReadLine());
										var department2 = context.Department.Include(d => d.Employees).Where(d => d.DepartmentID == dept2id).FirstOrDefault();
										if (department2 != null)
										{
											Console.WriteLine("enter number of employees you want to add to the department ");
											int size = int.Parse(Console.ReadLine());
											for (int i = 0; i < size; i++)
											{
												Console.WriteLine("enter Employee ID : ");
												int emp_id = int.Parse(Console.ReadLine());
												var emps = context.Employee.Include(e => e.Department).Where(e => e.EmployeeID == emp_id).FirstOrDefault();
												if (emps != null)
												{
													if (emps.DepartmentID != dept2id)
													{
														//department2.Employees.Add(emps);
														emps.DepartmentID = dept2id;
														context.SaveChanges();
														Console.WriteLine("employee added sucessfully to the department");
													}
													else
													{
														Console.WriteLine("employee already existsin the department");
													}
												}
												else
												{
													Console.WriteLine("employee not exists");
												}



											}

										}
										else
										{
											Console.WriteLine("department not found");
										}
										break;
								}
								break;//EDIT Department DATA
							case "3"://EDIT PROJECT DATA
								Console.WriteLine("3.1-Project Data");
								Console.WriteLine("3.2-Assign Employees to Project");
								string project_edit_selection = Console.ReadLine();
								switch (project_edit_selection)
								{
									case "3.1":
										Console.WriteLine("enter project id");
										int projectid = int.Parse(Console.ReadLine());
										var project3 = context.Projects.Include(p => p.Emp_proj).ThenInclude(ep => ep.Employee).Where(p => p.ProjectID == projectid).FirstOrDefault();
										if (project3 != null)
										{
											Console.WriteLine($"{project3.ProjectID}");
											Console.WriteLine($"{project3.Project_Name}");
											foreach (var Emp in project3.Emp_proj)
											{
												Console.WriteLine($"{Emp.Employee.EmployeeID}");
												Console.WriteLine($"{Emp.Employee.Employee_Firstname}");
												Console.WriteLine($"{Emp.Employee.Employee_Lastname}");
											}
											Console.WriteLine("1-Project Name");
											Console.WriteLine("2-Start Date");
											Console.WriteLine("3-End Date");
											Console.WriteLine("select option you want to edit ");
											string clicked = Console.ReadLine();
											switch (clicked)
											{
												case "1":
													Console.WriteLine("enter new project name ");
													project3.Project_Name = Console.ReadLine();
													context.SaveChanges();
													Console.WriteLine("project name changed successfully");
													break;
												case "2":
													Console.WriteLine("enter new project Start Date ");
													project3.StartDate = DateOnly.Parse(Console.ReadLine());
													context.SaveChanges();
													Console.WriteLine("project start date changed successfully");
													break;
												case "3":
													Console.WriteLine("enter new project End Date ");
													project3.EndDate = DateOnly.Parse(Console.ReadLine());
													context.SaveChanges();
													Console.WriteLine("project end date changed successfully");
													break;
											}
										}
										else
										{
											Console.WriteLine("project not exists in the database");
										}
										break;
									case "3.2":
										Console.WriteLine("enter project id");
										int proj_ID = int.Parse(Console.ReadLine());
										var project4 = context.Projects.Include(p => p.Emp_proj).ThenInclude(ep => ep.Employee).FirstOrDefault(p => p.ProjectID == proj_ID);
										if (project4 != null)
										{
											Console.WriteLine("enter employee id you want to assign to project");
											int emps_ID = int.Parse(Console.ReadLine());
											bool isexiststhelink = context.Employee_Projects.Any(ep => ep.ProjectID == project4.ProjectID && ep.EmployeeID == emps_ID);
											if (!isexiststhelink)
											{
												var Emp_project = new Employee_Project()
												{
													EmployeeID = emps_ID,
													ProjectID = project4.ProjectID
												};
												context.Employee_Projects.Add(Emp_project);
												context.SaveChanges();

											}
											else
											{
												Console.WriteLine("employee is already asiinged to this project");
											}


										}
										else
										{
											Console.WriteLine("project not found");
										}
										break;
								}
								break;//EDIT PROJECT DATA
						}
						break; //EDIT --DONE

					case "4":
						Console.WriteLine("1-Employee");
						Console.WriteLine("2-Department");
						Console.WriteLine("3-Project");
						string delete_option = Console.ReadLine();
						switch (delete_option)
						{
							case "1":
								Console.WriteLine("enter id of the employee you want to remove");
								int emp_IDD = int.Parse(Console.ReadLine());
								var employee7 = context.Employee.Include(e => e.Department).Include(e => e.Emp_proj).ThenInclude(ep => ep.Project).FirstOrDefault(e => e.EmployeeID == emp_IDD);
								if (employee7 != null)
								{
									var emp_proj = context.Employee_Projects.Where(ep => ep.EmployeeID == emp_IDD).ToList();//list of projects employee works on
									context.Employee_Projects.RemoveRange(emp_proj);
									context.Employee.Remove(employee7);
									context.SaveChanges();
								}
								break;
							case "2":
								Console.WriteLine("enter id of the department you want to delete");
								int dept_iD = int.Parse(Console.ReadLine());
								var depttt = context.Department.Include(d => d.Employees).FirstOrDefault(d => d.DepartmentID == dept_iD);
								if (depttt != null)
								{
									foreach (var emp in depttt.Employees)
									{
										emp.DepartmentID = null;
									}
									context.Department.Remove(depttt);
									context.SaveChanges();
								}
								else
								{
									Console.WriteLine("dept not found");
								}


								break;
							case "3":
								Console.WriteLine("enter project id you want to delete");
								int projectt_ID = int.Parse(Console.ReadLine());
								var proj = context.Projects.Include(p => p.Emp_proj).ThenInclude(ep => ep.Employee).FirstOrDefault(p => p.ProjectID == projectt_ID);
								if (proj != null)
								{
									var Emp_projjjj = context.Employee_Projects.Where(pj => pj.ProjectID == projectt_ID).ToList();
									context.Employee_Projects.RemoveRange(Emp_projjjj);
									context.Projects.Remove(proj);
									context.SaveChanges();
								}


								break;
						}
						break; //DELETE
				}
			}







		}

    }
}
