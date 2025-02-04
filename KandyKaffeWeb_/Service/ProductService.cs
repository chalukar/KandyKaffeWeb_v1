using KandyKaffeWeb_.Models;
using KandyKaffeWeb_.Service.IService;
using KandyKaffeWeb_.Utility;
using KandyKaffeWeb_.Models;
using static KandyKaffeWeb_.Utility.SD;

namespace KandyKaffeWeb_.Service
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;

        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        // Create Product
        public async Task<ResponseDto?> CreateProductAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/product/"
            });
        }

        // Update Product
        public async Task<ResponseDto?> UpdateProductAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.PUT,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/product/"
            });
        }

        // Delete Product
        public async Task<ResponseDto?> DeleteProductAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/product/" + id
            });
        }

        // Get All Product
        public async Task<ResponseDto?> GetAllProductAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.ProductAPIBase + "/api/product"
            });
        }

        //// Get Product
        //public async Task<ResponseDto?> GetProductAsync(string ProductCode)
        //{
        //    return await _baseService.SendAsync(new RequestDto()
        //    {
        //        ApiType = ApiType.GET,
        //        Url = SD.ProductAPIBase + "/api/Product/GetByCode/" + ProductCode
        //    });
        //}

        // Get Product By Id
        public async Task<ResponseDto?> GetProductByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.ProductAPIBase + "/api/product/" + id
            });
        }


    }
}
