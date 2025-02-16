namespace OnlineShop.Repository.Photo
{
    public interface IUploadPhotoRepository
    {
        Task AddPhotoAsync(entities.SellerInfo sellerInfo);
    }
}
