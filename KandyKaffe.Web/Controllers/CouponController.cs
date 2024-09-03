using KandyKaffe.Web.Models;
using KandyKaffe.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace KandyKaffe.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService; 
        }
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? list = new();
            ResponseDto responseDto = await _couponService.GetAllCouponAsync();
            if (responseDto != null && responseDto.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(responseDto.Result));
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }
            return View(list);
        }

        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> CouponCreate(CouponDto model)
		{
            if(ModelState.IsValid)
            {
				ResponseDto responseDto = await _couponService.CreateCouponAsync(model);
				if (responseDto != null && responseDto.IsSuccess)
				{
                    TempData["success"] = "Coupon created successfully";
                    return RedirectToAction(nameof(CouponIndex));
				}
                else
                {
                    TempData["error"] = responseDto?.Message;
                }
            }
			return View(model);
		}

        
		public async Task<IActionResult> CouponDelete(int couponId)
		{
			ResponseDto responseDto = await _couponService.GetCouponByIdAsync(couponId);
			if (responseDto != null && responseDto.IsSuccess)
			{
				CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(responseDto.Result));
                return View(model);
			}
            else
            {
                TempData["error"] = responseDto?.Message;
            }
            return NotFound();
		}

        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDto couponDto)
        {
            ResponseDto responseDto = await _couponService.DeleteCouponAsync(couponDto.CouponId);
            if (responseDto != null && responseDto.IsSuccess)
            {
                TempData["success"] = "Coupon deleted successfully";
                return RedirectToAction(nameof(CouponIndex));
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }
            return View(couponDto);
        }
    }
}
