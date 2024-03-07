using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OSRSHelper.Data;

namespace OSRSHelper.Controllers
{
	public class ProductController : Controller
	{
		private readonly OSRSDbContext DbContext;

		public ProductController(OSRSDbContext dbContext)
		{
			DbContext = dbContext;
		}
		public async Task<IActionResult> Index(string MaterialName)
		{
            var products = await DbContext.Products.ToListAsync();

            if (!string.IsNullOrEmpty(MaterialName))
			{ 
				products = products.Where(p => p.ProductName.Contains(MaterialName)).ToList();
			}
            
            return View(products);
		}
	}
}
