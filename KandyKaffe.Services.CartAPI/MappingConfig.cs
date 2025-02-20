using AutoMapper;
using KandyKaffe.Services.CartAPI.Models;
using KandyKaffe.Services.CartAPI.Models.Dto;


namespace KandyKaffe.Services.CartAPI
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
