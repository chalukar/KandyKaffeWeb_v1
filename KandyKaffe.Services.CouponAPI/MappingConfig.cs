using Microsoft.EntityFrameworkCore.Metadata;
using AutoMapper;
using KandyKaffe.Services.CouponAPI.Models;
using KandyKaffe.Services.CouponAPI.Models.Dto;

namespace KandyKaffe.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto,Coupon>();
                config.CreateMap<Coupon,CouponDto>();
            });
            return mappingConfig;
        }

    }
}
