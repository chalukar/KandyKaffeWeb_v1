
using KandyKaffeWeb_.Models;


namespace KandyKaffeWeb_.Service.IService
{
    public interface IProductService
    {
        //Task<ResponseDto?> GetProductAsync(string ProductCode);
        Task<ResponseDto?> GetAllProductAsync();
        Task<ResponseDto?> GetProductByIdAsync(int id);
        Task<ResponseDto?> CreateProductAsync(ProductDto ProductDto);
        Task<ResponseDto?> UpdateProductAsync(ProductDto ProductDto);
        Task<ResponseDto?> DeleteProductAsync(int id);

    }
}
