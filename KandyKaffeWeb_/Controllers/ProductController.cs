using KandyKaffeWeb_.Models;
using KandyKaffeWeb_.Service.IService;
using KandyKaffeWeb_.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using KandyKaffeWeb_.Service.IService;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KandyKaffeWeb_.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> ProductIndex()
        {
            //List<CategoryDto> categories = new List<CategoryDto>();
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

        public async Task<IActionResult> ProductCreate()
        {
            await PopulateCategories();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductDto productDto)
        {
            
            if (ModelState.IsValid)
            {
                ResponseDto responseDto = await _productService.CreateProductAsync(productDto);
                if (responseDto != null && responseDto.IsSuccess)
                {
                    TempData["success"] = "Product created successfully";
                    return RedirectToAction(nameof(ProductIndex));
                }
                else
                {
                    TempData["error"] = responseDto?.Message ?? "Error creating product"; ;
                }
            }
            await PopulateCategories();
            return View(productDto);
        }


        public async Task<IActionResult> ProductDelete(int ProductId)
        {
            ResponseDto responseDto = await _productService.GetProductByIdAsync(ProductId);
            if (responseDto != null && responseDto.IsSuccess)
            {
                ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(responseDto.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductDto ProductDto)
        {
            ResponseDto responseDto = await _productService.DeleteProductAsync(ProductDto.ProductId);
            if (responseDto != null && responseDto.IsSuccess)
            {
                TempData["success"] = "Product deleted successfully";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }
            return View(ProductDto);
        }
		public async Task<IActionResult> ProductEdit(int ProductId)
		{
			ResponseDto responseDto = await _productService.GetProductByIdAsync(ProductId);
			if (responseDto != null && responseDto.IsSuccess)
			{
				ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(responseDto.Result));
                await PopulateCategories(model?.CategoryId);
                return View(model);
			}
			else
			{
				TempData["error"] = responseDto?.Message;
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> ProductEdit(ProductDto ProductDto)
		{
			ResponseDto responseDto = await _productService.UpdateProductAsync(ProductDto);
			if (responseDto != null && responseDto.IsSuccess)
			{
				TempData["success"] = "Product updated successfully";
				return RedirectToAction(nameof(ProductIndex));
			}
			else
			{
				TempData["error"] = responseDto?.Message;
			}
            await PopulateCategories(ProductDto.CategoryId);
            return View(ProductDto);
		}


		private async Task PopulateCategories(int? selectedCategoryId = null)
        {

            var response = await _categoryService.GetAllCategoryAsync();
            if (response.IsSuccess)
            {
                var categories = JsonConvert.DeserializeObject<List<CategoryDto>>(Convert.ToString(response.Result));
                ViewBag.CategoryList = new SelectList(categories, "Id", "CategoryName", selectedCategoryId);
            }


        }
    }
}
