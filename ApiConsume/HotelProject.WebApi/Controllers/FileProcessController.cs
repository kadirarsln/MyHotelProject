﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileProcessController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile formFile)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(formFile.FileName);                          //Uzantıyı almak için burayı kullanırız.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "files/" + fileName);                //Aktif yolu alıp kaydetmek istediğimiz yola kaydederiz. FileNmae den gelen değişken ile dosya adı ile kaydolur.
            var stream = new FileStream(path, FileMode.Create);                                            //Dosyanın oluşturulma modu için.
            await formFile.CopyToAsync(stream);
            return Created("", formFile);                                                                  //Geriyen oluşturuldu diye döneriz.
        }
    }
}
