using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebUI.Controllers
{
	public class DoctorController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Doctors()
		{
			return View();
		}

		public IActionResult DoctorSingle()
		{
			return View();
		}

		public IActionResult Appointment()
		{
			return View();
		}
	}
}
