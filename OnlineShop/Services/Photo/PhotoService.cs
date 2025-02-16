using OnlineShop.Models.SellerInfo;
using OnlineShop.Repository.Photo;
using System.Drawing;

namespace OnlineShop.Services.Photo
{
    public class PhotoService : IPhotoService
    {
        private readonly IUploadPhotoRepository _uploadphotoRepository;

        public PhotoService(IUploadPhotoRepository uploadphotoRepository)
        {
            _uploadphotoRepository = uploadphotoRepository;
        }

        public async Task AddPhoto(UploadPhotoRequest dto)
        {
            if (dto.Image.Length > 0)
            {
                using (var ms =  new MemoryStream())
                {
                    await dto.Image.CopyToAsync(ms);

                    var photo = new entities.SellerInfo
                    {
                        Photo = ms.ToArray()
                    };

                    await _uploadphotoRepository.AddPhotoAsync(photo);
                }
            }
            throw new Exception("Length is invalid");
        }
    }
}
