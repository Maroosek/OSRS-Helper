using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
			
			//ViewData["MaterialId"] = new SelectList(_DbContext.Materials, "MaterialId", "Material");


            if (id != 0)
			{

                var materials = products.Where(p => p.MaterialSecondId == id || p.MaterialId == id).ToList();
                //anonymous type to implement later
				/*var materials = products
				.Where(p => p.MaterialSecondId == id || p.MaterialId == id)
				.Select(p => new { Id = p.MaterialId == id ? p.MaterialId : p.MaterialSecondId, Product = p })
				.ToList();*/

                return View(materials);
			}

            /*if (!string.IsNullOrEmpty(MaterialName))
			{ 
				products = products.Where(p => p.ProductName.Contains(MaterialName)).ToList();
			}*/
            
            return View(products);
		}
		public async Task<IActionResult> Details()
		{
			return View();
		}
		
	}
}
