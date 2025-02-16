using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.SellerInfo;
using OnlineShop.Services.Photo;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("photo")]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }
        [HttpPost]
        [Route("upload")]

        public async Task<IActionResult> AddPhoto([FromForm] UploadPhotoRequest dto)
        {
            await _photoService.AddPhoto(dto);
            return Ok("Photo was added successfully!");
        }
    }
}
