using KandyKaffe.Services.AuthAPI.Models;

namespace KandyKaffe.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
