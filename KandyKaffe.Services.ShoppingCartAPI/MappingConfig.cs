using AutoMapper;
using KandyKaffe.Services.ShoppingCartAPI.Models;
using KandyKaffe.Services.ShoppingCartAPI.Models.Dto;


namespace KandyKaffe.Services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            });
            return mappingConfig;
        }

    }
}
