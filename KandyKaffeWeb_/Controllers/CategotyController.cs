using KandyKaffeWeb_.Models;
using KandyKaffeWeb_.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using KandyKaffeWeb_.Service.IService;

namespace KandyKaffeWeb_.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> CategoryIndex()
        {
            List<CategoryDto>? list = new();
            ResponseDto responseDto = await _categoryService.GetAllCategoryAsync();
            if (responseDto != null && responseDto.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CategoryDto>>(Convert.ToString(responseDto.Result));
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }
            return View(list);
        }

        public async Task<IActionResult> CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CategoryCreate(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto responseDto = await _categoryService.CreateCategoryAsync(categoryDto);
                if (responseDto != null && responseDto.IsSuccess)
                {
                    TempData["success"] = "Category created successfully";
                    return RedirectToAction(nameof(CategoryIndex));
                }
                else
                {
                    TempData["error"] = responseDto?.Message;
                }
            }
            return View(categoryDto);
        }


        public async Task<IActionResult> CategoryDelete(int CategoryId)
        {
            ResponseDto responseDto = await _categoryService.GetCategoryByIdAsync(CategoryId);
            if (responseDto != null && responseDto.IsSuccess)
            {
                CategoryDto? model = JsonConvert.DeserializeObject<CategoryDto>(Convert.ToString(responseDto.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CategoryDelete(CategoryDto CategoryDto)
        {
            ResponseDto responseDto = await _categoryService.DeleteCategoryAsync(CategoryDto.Id);
            if (responseDto != null && responseDto.IsSuccess)
            {
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction(nameof(CategoryIndex));
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }
            return View(CategoryDto);
        }
    }
}
