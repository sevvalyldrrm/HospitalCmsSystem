using HospitalCmsSystem.Dto.Blog;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Cms.Web.Mvc.Controllers
{
    public class BlogController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BlogController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7038//api/Blogs");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBlogDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		public IActionResult Details(int id)
		{
			return View();
		}
		public IActionResult Search(string quey, int id)
		{
			return View();
		}
	}
}
