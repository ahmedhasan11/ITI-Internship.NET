using Microsoft.AspNetCore.Mvc;

namespace MVC_D1_Project.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult GetProductsJson()
        {
				var products = new List<object>
			{
				new { Id = 1, Name = "Laptop", Price = 1000 },
				new { Id = 2, Name = "Phone", Price = 600 }
			};

			return Json(products);
        }
    }
}
