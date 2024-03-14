using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebUI.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
