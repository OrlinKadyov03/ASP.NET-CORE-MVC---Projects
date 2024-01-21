using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using Running.Helpers;
using Running.Interfaces;

namespace Running.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var acc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
              );
            _cloudinary = new Cloudinary(acc);
        }
        public Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
           var uploadResult = new ImageUploadResult();
        }

        public Task<DeletionResult> DeletePhotoAsync(string publicid)
        {
            throw new NotImplementedException();
        }
    }
}
