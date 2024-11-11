using KandyKaffeWeb_.Models;
using KandyKaffeWeb_.Service.IService;
using KandyKaffeWeb_.Models;
using Microsoft.AspNetCore.Mvc;

namespace KandyKaffeWeb_.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new();
            return View(loginRequestDto);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        public IActionResult Logout()
        {

            return View();
        }
    }
}
