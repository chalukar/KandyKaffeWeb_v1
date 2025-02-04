using AutoMapper;
using KandyKaffe.Service.CategoryAPI.Models;
using KandyKaffe.Service.CategoryAPI.Models.Dto;

namespace KandyKaffe.Services.CategoryAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CategoryDto, Category>().ReverseMap();
            });
            return mappingConfig;
        }

    }
}
