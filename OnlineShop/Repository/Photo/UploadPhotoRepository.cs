using OnlineShop.Data;
using OnlineShop.entities;

namespace OnlineShop.Repository.Photo
{
    public class UploadPhotoRepository : IUploadPhotoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UploadPhotoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddPhotoAsync(SellerInfo sellerInfo)
        {
            await _dbContext.SellerInfos.AddAsync(sellerInfo);
            await _dbContext.SaveChangesAsync();


        }
    }
}
