using HotelProject.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _OurRoomsPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _OurRoomsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();                                          // Consume için istemci oluşturuldu.
            var responseMessage = await client.GetAsync("http://localhost:62391/api/Room");          // Belirtilen adrese istekte bulunuldu.
            if (responseMessage.IsSuccessStatusCode)                                                 // Adresten başarılı durum kodu dönerse ,
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();                    // Gelen veriyi değişkene atadık. (JsonData)
                var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);          // Deserialize ile tabloda görülecek formata getirdik.
                return View(values);
            }
            return View();
        }
    }
}
