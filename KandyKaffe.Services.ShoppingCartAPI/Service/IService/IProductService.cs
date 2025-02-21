using KandyKaffe.Services.ShoppingCartAPI.Models.Dto;

namespace KandyKaffe.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
