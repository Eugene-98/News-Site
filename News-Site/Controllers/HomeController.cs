using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace News_Site.Controllers
{
	public class HomeController : Controller
	{
		[Authorize(Roles = "admin, user")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
