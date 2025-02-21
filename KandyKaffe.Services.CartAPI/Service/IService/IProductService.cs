using KandyKaffe.Services.CartAPI.Models.Dto;
namespace KandyKaffe.Services.CartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
