using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace News_Site.Controllers
{
	public class HomeController : Controller
	{
		[Authorize(Roles = "admin")]
		public IActionResult Index()
		{
			string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
			return Content($"ваша роль: {role}");
		}
	}
}
