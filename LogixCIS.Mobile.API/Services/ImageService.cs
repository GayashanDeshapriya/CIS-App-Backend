using LogixCIS.Auth.API.Models;
using LogixCIS.Mobile.API.Models.ImageModel;
using LogixCIS.Mobile.API.Repositories.ImageUploaderRepo;

namespace LogixCIS.Mobile.API.Services
{
    public class ImageService :IImageService
    {
        private readonly IImageUploaderRepository _imageUploaderRepository;
        public ImageService(IImageUploaderRepository imageUploaderRepository)
        {
            _imageUploaderRepository = imageUploaderRepository;
        }

        public Task<ResponseModel> UploadImage(ImageModel IFormFile, file )
        {
            throw new NotImplementedException();
        }
    }
}
