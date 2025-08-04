using Microsoft.EntityFrameworkCore;
using MVC_D2_Employee_DeptSystsem.Data;
using MVC_D2_Employee_DeptSystsem.Models;

namespace MVC_D2_Employee_DeptSystsem
{

	public interface IRepository<T> where T :class
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetByIDAsync(int id);
		Task AddAsync(T entity);

		void Update(T entity);

		void Delete(T entity);

		Task<int> SaveChangesAsync();
	}

	public class EmployeeRepo : IRepository<Employee>
	{
		private readonly SystemContext _context;

		public EmployeeRepo(SystemContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Employee>> GetAllAsync()
		{
			return await _context.Employee.Include(e => e.Department).ToListAsync();
		}
		public async Task<Employee> GetByIDAsync(int id)
		{
			var emp = await _context.Employee.Include(e=>e.Department).FirstOrDefaultAsync(e => e.EmployeeID == id);
			if (emp != null)
			{
				return emp ;
			}
			else
			{
				return null;
			}

		}

		public async Task AddAsync(Employee employee)
		{
			 await _context.Employee.AddAsync(employee);
		}

		public void Update(Employee employee)
		{
			_context.Employee.Update(employee);
		}
		public void Delete(Employee employee)
		{
			_context.Employee.Remove(employee);
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync();
		}
	}

	public class DepartmentRepo : IRepository<Department>
	{
		private readonly SystemContext _context;
		public DepartmentRepo(SystemContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Department>> GetAllAsync()
		{
			return await _context.Department.Include(d=>d.Employees).ToListAsync();
		}
		public async Task<Department> GetByIDAsync(int id)
		{
			var dept = await _context.Department.Include(d=>d.Employees).FirstOrDefaultAsync(d => d.DepartmentID == id);
			if (dept != null)
			{
				return dept;
			}
			else
			{
				return null;
			}

		}

		public async Task AddAsync(Department department)
		{
			await _context.Department.AddAsync(department);
		}

		public void Update(Department department)
		{
			_context.Department.Update(department);
		}
		public void Delete(Department department)
		{
			_context.Department.Remove(department);
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync();
		}
	}
}
