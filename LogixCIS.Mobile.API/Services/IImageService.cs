using LogixCIS.Auth.API.Models;
using LogixCIS.Mobile.API.Models.ImageModel;

namespace LogixCIS.Mobile.API.Services
{
    public interface IImageService
    {
        Task<ResponseModel> UploadImage(ImageModel IFormFile file);

    }
}
