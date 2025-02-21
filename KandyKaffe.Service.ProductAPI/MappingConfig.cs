using AutoMapper;
using KandyKaffe.Services.ProductAPI.Models;
using KandyKaffe.Services.ProductAPI.Models.Dto;


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
