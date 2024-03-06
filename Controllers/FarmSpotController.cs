using Microsoft.AspNetCore.Mvc;
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
			//IEnumerable<FarmSpot> farmSpots = DbContext.FarmSpots.ToList();

			return View(farmSpots);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(FarmSpot model)
		{
			var farmSpot = new FarmSpot
			{
				SpotName = model.SpotName,
				Time = model.Time,
				FarmType = model.FarmType
			};

            await DbContext.FarmSpots.AddAsync(farmSpot);
			await DbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

		public async Task<IActionResult> Delete(int id)
		{
            var farmSpot = await DbContext.FarmSpots.FindAsync(id);
			if (farmSpot == null)
			{
				return NotFound();
			}
            DbContext.FarmSpots.Remove(farmSpot);
            await DbContext.SaveChangesAsync();

			return RedirectToAction("Index");
			//return View(farmSpot);
        }
	}
}
