using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using MVC_D2_Employee_DeptSystsem.Models;

namespace MVC_D2_Employee_DeptSystsem.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IRepository<Department> deptrepo;
		private readonly IRepository<Employee> emprepo;

		public DepartmentController(IRepository<Department>DeptRepo,IRepository<Employee>EmpRepo)
        {
            deptrepo = DeptRepo;
            emprepo = EmpRepo;
        }
        public async Task<IActionResult> Index()
        {
            return View("Index",await deptrepo.GetAllAsync());
        }
        [HttpGet]
		[Authorize]
		public IActionResult Add()
		{
            return View("Add");

		}
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Add(Department department)
        {
           await deptrepo.AddAsync(department);
           await  deptrepo.SaveChangesAsync();
            return RedirectToAction("Index");

		}
        public async Task<IActionResult> Details(int id)
        {
            var dept = await deptrepo.GetByIDAsync(id);
            
            return View("Details",dept);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id )
        {
            return View("Edit",await deptrepo.GetByIDAsync(id));
        }
        [HttpPost]
		[Authorize]
		public async Task<IActionResult> Edit(Department department)
		{
            deptrepo.Update(department);
           await deptrepo.SaveChangesAsync();

            return RedirectToAction("Index");
		}
        [HttpGet]
		[Authorize]
		public async Task<IActionResult> Delete(int id)
        {
			return View("Delete",await deptrepo.GetByIDAsync(id));
		}
        [HttpPost]
		[Authorize]
		public async Task<IActionResult> Delete(Department department)
		{
            deptrepo.Delete(department);
           await deptrepo.SaveChangesAsync();
            return RedirectToAction("Index");
		}
	}
}
