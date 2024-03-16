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
            var farmTypes = await _DbContext.FarmTypes.ToListAsync();
            var materials = await _DbContext.Materials.ToListAsync();

            //ViewData["MaterialId"] = new SelectList(_DbContext.Materials, "MaterialId", "Material");


            if (id != 0)
			{

                var productsFiltered = products.Where(p => p.MaterialSecondId == id || p.MaterialId == id).ToList();
				//var joined = productsFiltered.Join(materials, p => p.MaterialId, m => m.MaterialId, (p, m) => new { p, m }).ToList();

				/*var joined = from p in productsFiltered
							 join m in materials on p.MaterialId equals m.MaterialId
							 join m2 in materials on p.MaterialSecondId equals m2.MaterialId
							 select new
							 {
								*//* p.FarmTypeId,
								 p.MaterialId,
								 p.MaterialSecondId,
								 p.ProductId,
								 p.ProductName*//*

							 };*/
				//joined.ToList();

                //anonymous type to implement later
                /*var materials = products
				.Where(p => p.MaterialSecondId == id || p.MaterialId == id)
				.Select(p => new { Id = p.MaterialId == id ? p.MaterialId : p.MaterialSecondId, Product = p })
				.ToList();*/

                return View(productsFiltered);
			}

            /*if (!string.IsNullOrEmpty(MaterialName))
			{ 
				products = products.Where(p => p.ProductName.Contains(MaterialName)).ToList();
			}*/
            
            return View(products);
		}
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
            ViewData["FarmTypeId"] = new SelectList(_DbContext.FarmTypes, "FarmTypeId", "FarmName");// needed for the dropdown list

            //var products = await _DbContext.Products.ToListAsync();
            var farmTypes = await _DbContext.FarmTypes.ToListAsync();
            var materials = await _DbContext.Materials.ToListAsync();
			var farmspot = await _DbContext.FarmSpots.ToListAsync();
            Product products = await _DbContext.Products.FindAsync(id);

/*			ViewData["FarmTypeId"] = new SelectList(_DbContext.FarmTypes, "FarmTypeId", "FarmName");
			ViewData["MaterialId"] = new SelectList(_DbContext.FarmTypes, "MaterialId", "MaterialName");*/

            /*var joined = from p in products
						 join ft in farmTypes on p.FarmTypeId equals ft.FarmTypeId
                         join m in materials on p.MaterialId equals m.MaterialId
						 join m2 in materials on p.MaterialSecondId equals m2.MaterialId
						 select new
						 {
							 p.ProductId,
							 p.ProductName,
                             p.FarmTypeId,
                             p.MaterialId,
                             p.MaterialSecondId
                         };*/

            return View(products);
		}
		
	}
}
