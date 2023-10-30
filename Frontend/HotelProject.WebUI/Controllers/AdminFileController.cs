﻿using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelProject.WebUI.Controllers
{
    public class AdminFileController : Controller
    {
        [HttpGet]
        public IActionResult AdminFileIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminFileIndex(IFormFile formFile)
        {
            var stream = new MemoryStream();                                                           //Dosya yükleme işlemi 
            await formFile.CopyToAsync(stream);                                                         //Dosyayı ilgili akış üzerinden kopyalıyoruz.
            var bytes = stream.ToArray();                                                               //Akıştaki dosyayı byte olarak tutuyoruz

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(formFile.ContentType);                                  //Dosyamızın içerik türünü gönderiyoruz.
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent, "formFile", formFile.FileName);                                          //ByteArray gelen değeri yükleriz.
            var httpClient = new HttpClient();
            await httpClient.PostAsync("http://localhost:62391/api/FileProcess", multipartFormDataContent);

            return View();
        }
    }
}
