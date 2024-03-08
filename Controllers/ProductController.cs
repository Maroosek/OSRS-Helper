using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OSRSHelper.Data;
using OSRSHelper.Models;

namespace OSRSHelper.Controllers
{
	public class ProductController : Controller
	{
		private readonly OSRSDbContext DbContext;

		public ProductController(OSRSDbContext dbContext)
		{
			DbContext = dbContext;
		}
		public async Task<IActionResult> Index(int MaterialId)
		{
            var products = await DbContext.Products.ToListAsync();

			if (MaterialId != 0)
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
