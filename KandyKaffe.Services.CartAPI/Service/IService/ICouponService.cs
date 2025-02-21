using KandyKaffe.Services.CartAPI.Models.Dto;

namespace KandyKaffe.Services.CartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponcode);
    }
}
