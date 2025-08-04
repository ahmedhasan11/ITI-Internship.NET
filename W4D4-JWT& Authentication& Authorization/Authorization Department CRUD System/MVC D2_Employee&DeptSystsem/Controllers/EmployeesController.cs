using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_D2_Employee_DeptSystsem.Data;
using MVC_D2_Employee_DeptSystsem.Models;

namespace MVC_D2_Employee_DeptSystsem.Controllers
{
    public class EmployeesController : Controller
    {
		private readonly IRepository<Department> _deptrepo;
		private readonly IRepository<Employee> _emprepo;

        public EmployeesController(IRepository<Employee> EmpRepo,IRepository<Department>DeptRepo)
        {
            _emprepo=EmpRepo;
            _deptrepo = DeptRepo;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _emprepo.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View("Details",await _emprepo.GetByIDAsync(id));
        }
		[Authorize]
		[HttpGet]
        public async Task<IActionResult> Add()
		{

			var departments = await _deptrepo.GetAllAsync();
			ViewBag.Departments = new SelectList(departments, "DepartmentID", "DepartmentName");
			return View("Add");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> Add(Employee employee)
        {
            await _emprepo.AddAsync(employee);
            await _emprepo.SaveChangesAsync();

            return RedirectToAction("Index");

        }
		[Authorize]
		[HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
			var employee = await _emprepo.GetByIDAsync(id);
			var departments = await _deptrepo.GetAllAsync();

			ViewBag.Dept_ID = new SelectList(departments, "DepartmentID", "DepartmentName", employee.Dept_ID);
			return View(employee);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> Edit( Employee employee)
        {
             _emprepo.Update(employee);
            await _emprepo.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
		}

        [HttpGet]
		[Authorize]
		public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _emprepo.GetByIDAsync(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> Delete(Employee employee)
        {

             _emprepo.Delete(employee);
            await _emprepo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
