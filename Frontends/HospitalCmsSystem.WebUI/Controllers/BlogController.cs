using HospitalCmsSystem.Dto.Blog;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HospitalCmsSystem.WebUI.Controllers
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
			var responseMessage = await client.GetAsync("https://localhost:7038/api/Blogs/GetBlogWithIncludeQuery");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBlogWithIncludeDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		public IActionResult BlogSingle(int id)
		{
			return View();
		}
		
	}
}
