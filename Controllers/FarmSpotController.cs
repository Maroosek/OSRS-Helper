using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OSRSHelper.Data;
using OSRSHelper.Models;

namespace OSRSHelper.Controllers
{
	public class FarmSpotController : Controller
	{
		private readonly OSRSDbContext DbContext;

		public FarmSpotController(OSRSDbContext dbContext)
		{
            DbContext = dbContext;
        }
		
		public async Task<IActionResult> Index()
		{
			var farmSpots = await DbContext.FarmSpots.ToListAsync();
			//Not sure about that structure
			//var farmSpots = await DbContext.Products.Include(p => p.FarmType).ToListAsync();
			return View(farmSpots);
		}

		public IActionResult Create()
		{
			//Need this to show the dropdown list properly
			ViewData["FarmTypeId"] = new SelectList(DbContext.FarmTypes, "FarmTypeId", "FarmTypeId");

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(FarmSpot farmSpot)
        //[Bind("FarmSpotId, SpotName, Time, FarmTypeId")]
        {
            //This is bad structure
            /*var farmSpot = new FarmSpot
			{
				SpotName = model.SpotName,
				Time = model.Time,
				FarmType = model.FarmType
			};*/

            if (!ModelState.IsValid)
			{
                await DbContext.FarmSpots.AddAsync(farmSpot);
                await DbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewData["FarmTypeId"] = new SelectList(DbContext.FarmTypes, "FarmTypeId", "FarmTypeId", farmSpot.FarmTypeId);

			return View(farmSpot);
        }

		public async Task<IActionResult> Delete(int? id)
		{
            
			if (id == null)
			{
				return NotFound();
			}

            var farmSpot = await DbContext.FarmSpots.FindAsync(id);

            if (farmSpot != null)
            {
                DbContext.FarmSpots.Remove(farmSpot);
                await DbContext.SaveChangesAsync();
            }

			return RedirectToAction("Index");
        }
        //TODO fix delete, this structure should be used
        /*public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var farmSpot = await DbContext.FarmSpots.
                Include(f => f.FarmType).
                FirstOrDefaultAsync(f => f.FarmSpotId == id);

            if (farmSpot == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmSpot = await DbContext.FarmSpots.FindAsync(id);
            if (farmSpot != null)
            {
                DbContext.FarmSpots.Remove(farmSpot);
            }
            await DbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }*/
    }
}
