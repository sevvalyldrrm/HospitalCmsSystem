using HospitalCmsSystem.Dto.Blog;
using HospitalCmsSystem.Dto.Department;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HospitalCmsSystem.WebUI.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public DepartmentController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7038/api/Departments");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultDepartmentDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		public IActionResult DepartmanSingle(int id)
		{
			return View();	
		}
	}
}
