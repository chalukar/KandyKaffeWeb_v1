using KandyKaffe.Services.ShoppingCartAPI.Models.Dto;

namespace KandyKaffe.Services.ShoppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponcode);
    }
}
