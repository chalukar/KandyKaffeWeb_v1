using KandyKaffeWeb_.Models;
using KandyKaffeWeb_.Service.IService;
using KandyKaffeWeb_.Utility;
using KandyKaffeWeb_.Models;
using static KandyKaffeWeb_.Utility.SD;

namespace KandyKaffeWeb_.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseService _baseService;

        public CategoryService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        // Create Category
        public async Task<ResponseDto?> CreateCategoryAsync(CategoryDto categoryDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Data = categoryDto,
                Url = SD.CategoryAPIBase + "/api/category/"
            });
        }

        // Update Category
        public async Task<ResponseDto?> UpdateCategoryAsync(CategoryDto categoryDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.PUT,
                Data = categoryDto,
                Url = SD.CategoryAPIBase + "/api/category/"
            });
        }

        // Delete Category
        public async Task<ResponseDto?> DeleteCategoryAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.DELETE,
                Url = SD.CategoryAPIBase + "/api/category/" + id
            });
        }

        // Get All Category
        public async Task<ResponseDto?> GetAllCategoryAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.CategoryAPIBase + "/api/category"
            });
        }

        // Get Category
        public async Task<ResponseDto?> GetCategoryAsync(string CategoryCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.CategoryAPIBase + "/api/Category/GetByCode/" + CategoryCode
            });
        }

        // Get Category By Id
        public async Task<ResponseDto?> GetCategoryByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.CategoryAPIBase + "/api/category/" + id
            });
        }


    }
}
