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
	}
}
