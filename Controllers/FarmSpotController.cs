using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OSRSHelper.Data;
using OSRSHelper.Models;

namespace OSRSHelper.Controllers
{
	public class FarmSpotController : Controller
	{
		private readonly OSRSDbContext _DbContext;

		public FarmSpotController(OSRSDbContext dbContext)
		{
            _DbContext = dbContext;
        }
		
		public async Task<IActionResult> Index()
		{
			var farmSpots = await _DbContext.FarmSpots.ToListAsync();

            //ViewData["FarmTypeId"] = new SelectList(_DbContext.FarmTypes, "FarmTypeId", "FarmName");

            //Not sure about that structure
            //var farmSpots = await DbContext.Products.Include(p => p.FarmType).ToListAsync();
            return View(farmSpots);
		}

		public IActionResult Create()
		{
			//Need this to show the dropdown list properly
			ViewData["FarmTypeId"] = new SelectList(_DbContext.FarmTypes, "FarmTypeId", "FarmName");

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(FarmSpot farmSpot)
        {
            if (!ModelState.IsValid) //expand this
			{
                await _DbContext.FarmSpots.AddAsync(farmSpot);
                await _DbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

			ViewData["FarmTypeId"] = new SelectList(_DbContext.FarmTypes, "FarmTypeId", "FarmName");//, farmSpot.FarmTypeId);

			return View(farmSpot);
        }

		public async Task<IActionResult> Edit(int? id)
		{
			ViewData["FarmTypeId"] = new SelectList(_DbContext.FarmTypes, "FarmTypeId", "FarmName");// needed for the dropdown list
			
			if (id == null || id == 0)
			{
				return NotFound();
			}
			FarmSpot farmSpot = await _DbContext.FarmSpots.FindAsync(id);
			if (farmSpot == null)
			{
				return NotFound();
			}
			return View(farmSpot);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(FarmSpot farmSpot)
		{

            if (!ModelState.IsValid) //add model validation
            {

                var farmSpotInDb = await _DbContext.FarmSpots.FindAsync(farmSpot.FarmSpotId);

                if (farmSpotInDb == null)
                {
                    return NotFound();
                }

                farmSpotInDb.SpotName = farmSpot.SpotName;
                farmSpotInDb.Time = farmSpot.Time;
                farmSpotInDb.FarmTypeId = farmSpot.FarmTypeId;

                _DbContext.FarmSpots.Update(farmSpotInDb);
                _DbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(farmSpot);
        }
        //TODO fix delete
        public async Task<IActionResult> Delete(int? id)
		{
            
			if (id == null)
			{
				return NotFound();
			}

            var farmSpot = await _DbContext.FarmSpots.FindAsync(id);

            if (farmSpot != null)
            {
                _DbContext.FarmSpots.Remove(farmSpot);
                await _DbContext.SaveChangesAsync();
            }

			return RedirectToAction("Index");
        }
    }
}
