using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OSRSHelper.Data;
using OSRSHelper.Models;

namespace OSRSHelper.Controllers
{
	public class ProductController : Controller
	{
		private readonly OSRSDbContext _DbContext;

		public ProductController(OSRSDbContext dbContext)
		{
			_DbContext = dbContext;
		}
		public async Task<IActionResult> Index(int id)
		{
            var products = await _DbContext.Products.ToListAsync();

			if (id != 0)
			{
				//products = products.Where(p => p.MaterialId == MaterialId).ToList();

				return View();
			}

            /*if (!string.IsNullOrEmpty(MaterialName))
			{ 
				products = products.Where(p => p.ProductName.Contains(MaterialName)).ToList();
			}*/
            
            return View(products);
		}
	}
}
