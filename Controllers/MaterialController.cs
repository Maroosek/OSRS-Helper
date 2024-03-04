using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OSRSHelper.Data;

namespace OSRSHelper.Controllers
{
	public class MaterialController : Controller
	{
		private readonly OSRSDbContext DbContext;

		public MaterialController(OSRSDbContext dbContext)
		{
			DbContext = dbContext;
		}
		public async Task<IActionResult> Index()
		{
			var materials = await DbContext.Materials.ToListAsync();
			return View(materials);
		}
	}
}
