using HospitalCmsSystem.Dto.Blog;
using HospitalCmsSystem.Dto.Doctor;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HospitalCmsSystem.WebUI.Controllers
{
	public class DoctorController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public DoctorController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Doctors()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7038/api/Doctors/GetDoctorsWithDepartment");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultDoctorsWithDepartmentDto>>(jsonData);
				return View(values);
			}
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
