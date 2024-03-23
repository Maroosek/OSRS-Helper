using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OSRSHelper.Data;
using OSRSHelper.Models;
using OSRSHelper.Models.ViewModels;
using System.Dynamic;

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
		public async Task<IActionResult> Details(int? id, int? farmTypeId, int? productId)
		{
			if (id == null)
			{
				return NotFound();
			}
            //ViewData["FarmTypeId"] = new SelectList(_DbContext.FarmTypes, "FarmTypeId", "FarmName");// needed for the dropdown list

            ViewData["ProductId"] = new SelectList(_DbContext.Products, "ProductId", "ProductName");// needed for the dropdown list
            ViewData["FarmSpotId"] = new SelectList(_DbContext.FarmSpots, "FarmSpotId", "SpotName");// needed for the dropdown list


            //var products = await _DbContext.Products.ToListAsync();
            var farmTypes = await _DbContext.FarmTypes.ToListAsync();
            var materials = await _DbContext.Materials.ToListAsync();
			//var farmspot = await _DbContext.FarmSpots.ToListAsync();
            Product products = await _DbContext.Products.FindAsync(id);
			//dynamic combined = new ExpandoObject();
			//combined.Product = products;

			ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Products = products;
            Product secondProduct = await _DbContext.Products.FindAsync(productId);
            productViewModel.ProductSecond = secondProduct;

            if (productViewModel.ProductSecond != null)
			{
                //ViewData["SecondProduct"] = await _DbContext.Products.FindAsync(productId);
/*                Product secondProduct = await _DbContext.Products.FindAsync(productId);
				productViewModel.ProductSecond = secondProduct;*/
				//combined.SecondProduct = secondProduct;
                
				if (farmTypeId != null)
                {
                    //ViewData["SelectedFarm"] = await _DbContext.FarmTypes.FindAsync(farmTypeId);
                    FarmType selectedFarm = await _DbContext.FarmTypes.FindAsync(farmTypeId);
					productViewModel.FarmTypes = selectedFarm;
                    productViewModel.Products.ProductValue = (productViewModel.Products.ProductValue * 30);
                    productViewModel.ProductSecond.ProductExperience = (productViewModel.Products.ProductExperience * 30);
					//combined.FarmType = selectedFarm;
                    
					return View(productViewModel); // change to dynamic
                }
                productViewModel.Products.ProductValue = (productViewModel.Products.ProductValue * 60);
                productViewModel.Products.ProductExperience = (productViewModel.Products.ProductExperience * 60);
                
				return View(productViewModel);
            }
			
			/*products.ProductValue = (int)(products.ProductValue * 60);
			products.ProductExperience = (int)(products.ProductExperience * 60);*/

/*			ViewData["FarmTypeId"] = new SelectList(_DbContext.FarmTypes, "FarmTypeId", "FarmName");
			ViewData["MaterialId"] = new SelectList(_DbContext.FarmTypes, "MaterialId", "MaterialName");*/
			/*var spots = from fs in farmspot
						select new { fs.FarmSpotId, fs.SpotName };*/
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

            return View(productViewModel);// return dynamic with two products
		}

/*		public async Task<IActionResult> MeasureTime(int? id)
		{
			ViewData["FarmTypeId"] = new SelectList(_DbContext.FarmTypes, "FarmTypeId", "FarmName");
			ViewData["MaterialId"] = new SelectList(_DbContext.Materials, "MaterialId", "MaterialName");
			return View();
		}*/
		
	}
}
