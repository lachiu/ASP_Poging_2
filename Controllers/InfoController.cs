using Microsoft.AspNetCore.Mvc;

namespace VoorraadSysteem.Controllers
{
	public class InfoController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
