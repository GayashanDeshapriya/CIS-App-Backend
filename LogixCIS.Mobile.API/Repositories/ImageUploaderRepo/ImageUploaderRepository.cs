using LogixCIS.Auth.API.Data;

namespace LogixCIS.Mobile.API.Repositories.ImageUploaderRepo
{
    public class ImageUploaderRepository: IImageUploaderRepository
    {
        private readonly DataContext DbContext;
        private readonly IConfiguration config;

        public ImageUploaderRepository(DataContext context, IConfiguration config)
        {
            DbContext = context;
            this.config = config;

        }
    }
}
