using AutoMapper;
using KandyKaffe.Service.ProductAPI.Models;
using KandyKaffe.Service.ProductAPI.Models.Dto;


namespace KandyKaffe.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });
            return mappingConfig;
        }

    }
}
