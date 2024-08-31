using KandyKaffe.Web.Models;

namespace KandyKaffe.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?>SendAsync(RequestDto requestDto);

    }
}
