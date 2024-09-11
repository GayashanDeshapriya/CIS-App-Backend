using LogixCIS.Auth.API.Services;
using LogixCIS.Mobile.API.Models.ImageModel;
using LogixCIS.Mobile.API.Repositories.ImageUploaderRepo;
using LogixCIS.Mobile.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogixCIS.Mobile.API.Controllers.ImageUploader
{

    [ApiController]
    [Route("api/[controller]")]
    public class ImageUploaderController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IImageService imageService;

        public ImageUploaderController(IImageService ImageService, IConfiguration configuration)
        {
            imageService = ImageService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("upload")]

        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            var result = await imageService.UploadImage(IFormFile file);

            if (result.Status)
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized(result);
            }
        }

    }
}
