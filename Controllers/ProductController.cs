using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OSRSHelper.Data;
using OSRSHelper.Models;
using OSRSHelper.Models.ViewModels;
using System.Dynamic;
using System.Linq;

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

                return View(productsFiltered);
			}

            /*if (!string.IsNullOrEmpty(MaterialName))
			{ 
				products = products.Where(p => p.ProductName.Contains(MaterialName)).ToList();
			}*/
            
            return View(products);
		}
		public async Task<IActionResult> Details(int id, int? productId, int? farmTypeId)
		{
			if (id == null)
			{
				return NotFound();
			}
            Product products = await _DbContext.Products.FindAsync(id);
            var farmTypes = await _DbContext.FarmTypes.ToListAsync();
            var materials = await _DbContext.Materials.ToListAsync();

            ViewData["ProductId"] = new SelectList(_DbContext.Products.Where(x => x.FarmTypeId == products.FarmTypeId), "ProductId", "ProductName");// needed for the dropdown list
            ViewData["FarmSpotId"] = new SelectList(_DbContext.FarmSpots.Where(x => x.FarmTypeId.Value == products.FarmTypeId), "FarmSpotId", "SpotName");//;// needed for the dropdown list

            MultipleProducts CombinedProducts = new MultipleProducts();
            CombinedProducts.Product = products;
			
			if (productId != null)
			{
                Product secondProduct = await _DbContext.Products.FindAsync(productId);
				CombinedProducts.ProductSecond = secondProduct;
                
				if (farmTypeId != null)
                {
                    FarmSpot selectedFarm = await _DbContext.FarmSpots.FindAsync(farmTypeId);
					CombinedProducts.farmSpot = selectedFarm;
                    CombinedProducts.Product.ProductValue = (CombinedProducts.Product.ProductValue * CombinedProducts.farmSpot.Time);
                    CombinedProducts.Product.ProductExperience = (CombinedProducts.Product.ProductExperience * CombinedProducts.farmSpot.Time);
                    CombinedProducts.ProductSecond.ProductValue = (CombinedProducts.ProductSecond.ProductValue * CombinedProducts.farmSpot.Time);
                    CombinedProducts.ProductSecond.ProductExperience = (CombinedProducts.ProductSecond.ProductExperience * CombinedProducts.farmSpot.Time);

                    return View(CombinedProducts);
                }
				
				return View(CombinedProducts);
            }

            return View(CombinedProducts);
		}
	}
}
