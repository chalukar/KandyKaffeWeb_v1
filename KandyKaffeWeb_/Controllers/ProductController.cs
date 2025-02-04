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
            List<ProductDto>? list = new();
            ResponseDto responseDto = await _productService.GetAllProductAsync();
            if (responseDto != null && responseDto.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(responseDto.Result));
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }
            return View(list);
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


        private async Task PopulateCategories()
        {

            var response = await _categoryService.GetAllCategoryAsync();
            if (response.IsSuccess)
            {
                var categories = JsonConvert.DeserializeObject<List<CategoryDto>>(Convert.ToString(response.Result));
                ViewBag.CategoryList = new SelectList(categories, "Id", "CategoryName");
            }


        }
    }
}
