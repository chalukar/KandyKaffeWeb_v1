using KandyKaffeWeb_.Models;
using KandyKaffeWeb_.Models;

namespace KandyKaffeWeb_.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> RegisterAsync(RegistrationRequestsDto registrationRequestsDto);
        Task<ResponseDto?> AssignRoleAsync(RegistrationRequestsDto registrationRequestsDto);
    }
}
