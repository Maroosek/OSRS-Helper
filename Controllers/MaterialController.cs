using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OSRSHelper.Data;

namespace OSRSHelper.Controllers
{
	public class MaterialController : Controller
	{
		private readonly OSRSDbContext _DbContext;

		public MaterialController(OSRSDbContext dbContext)
		{
			_DbContext = dbContext;
		}
		public async Task<IActionResult> Index()
		{
			var materials = await _DbContext.Materials.ToListAsync();
			return View(materials);
		}
	}
}
