using Microsoft.AspNetCore.Mvc;

namespace OSRSHelper.Controllers
{
	public class FarmSpotController : Controller
	{
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
	}
}
