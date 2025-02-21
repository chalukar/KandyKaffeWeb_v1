
using KandyKaffeWeb_.Models;


namespace KandyKaffeWeb_.Service.IService
{
    public interface ICategoryService
    {
        Task<ResponseDto?> GetCategoryAsync(string CategoryCode);
        Task<ResponseDto?> GetAllCategoryAsync();
        Task<ResponseDto?> GetCategoryByIdAsync(int id);
        Task<ResponseDto?> CreateCategoryAsync(CategoryDto categoryDto);
        Task<ResponseDto?> UpdateCategoryAsync(CategoryDto categoryDto);
        Task<ResponseDto?> DeleteCategoryAsync(int id);

    }
}
