using OnlineShop.Models.SellerInfo;

namespace OnlineShop.Services.Photo
{
    public interface IPhotoService
    {
        Task AddPhoto(UploadPhotoRequest dto);
    }
}
