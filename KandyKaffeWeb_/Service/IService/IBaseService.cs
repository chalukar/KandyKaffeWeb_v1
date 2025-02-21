using KandyKaffeWeb_.Models;

namespace KandyKaffeWeb_.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);

    }
}
