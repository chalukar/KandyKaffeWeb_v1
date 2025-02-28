﻿using KandyKaffe.Services.CartAPI.Models.Dto;
using KandyKaffe.Services.CartAPI.Service.IService;
using Newtonsoft.Json;

namespace KandyKaffe.Services.CartAPI.Service
{
    public class ProductService : IProductService
    {
        private  readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory ClientFactory)
        {
            _httpClientFactory = ClientFactory;
        }
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient("Product");
            var response = await client.GetAsync($"/api/product");
            var apiContet = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContet);
            if(resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(Convert.ToString(resp.Result));
            }
            return new List<ProductDto>();
        }
    }
}
