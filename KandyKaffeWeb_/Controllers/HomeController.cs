using KandyKaffeWeb_.Models;
using KandyKaffeWeb_.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace KandyKaffeWeb_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;

		public HomeController(ILogger<HomeController> logger, IProductService productService, ICategoryService categoryService)
        {
            _logger = logger;
			_productService = productService;
			_categoryService = categoryService;
		}

        public async Task<IActionResult> Index()
        {
			List<CategoryDto> categories = new List<CategoryDto>();
			List<ProductDto>? productList = new();
			List<CategoryDto>? categoryList = new();
			ResponseDto productResponseDto = await _productService.GetAllProductAsync();
			ResponseDto categoryResponseDto = await _categoryService.GetAllCategoryAsync();

			if (productResponseDto != null && productResponseDto.IsSuccess && categoryResponseDto != null && categoryResponseDto.IsSuccess)
			{
				productList = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(productResponseDto.Result));
				categoryList = JsonConvert.DeserializeObject<List<CategoryDto>>(Convert.ToString(categoryResponseDto.Result));

				if (productList != null && categoryList != null)
				{
					// Match each product with its category name using CategoryId
					foreach (var product in productList)
					{
						var category = categoryList.FirstOrDefault(c => c.Id == product.CategoryId);
						product.CategoryName = category != null ? category.CategoryName : "Unknown"; // Default if Category is missing
					}
				}
			}
			else
			{
				TempData["error"] = productResponseDto?.Message;
			}
			return View(productList);
		}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
