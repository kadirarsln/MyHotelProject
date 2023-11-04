using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();                                          // Consume için istemci oluşturuldu.
            var responseMessage = await client.GetAsync("http://localhost:62391/api/DashboardWidgets/StaffCount");          // Belirtilen adrese istekte bulunuldu.
            var jsonData = await responseMessage.Content.ReadAsStringAsync();                    // Gelen veriyi değişkene atadık. (JsonData)              
            ViewBag.staffCount = jsonData;

            var client2 = _httpClientFactory.CreateClient();                                          // Consume için istemci oluşturuldu.
            var responseMessage2 = await client.GetAsync("http://localhost:62391/api/DashboardWidgets/BookingCount");          // Belirtilen adrese istekte bulunuldu.
            var jsonData2 = await responseMessage.Content.ReadAsStringAsync();                    // Gelen veriyi değişkene atadık. (JsonData)              
            ViewBag.bookingCount = jsonData;

            var client3 = _httpClientFactory.CreateClient();                                          // Consume için istemci oluşturuldu.
            var responseMessage3 = await client.GetAsync("http://localhost:62391/api/DashboardWidgets/AppUserCount");          // Belirtilen adrese istekte bulunuldu.
            var jsonData3 = await responseMessage.Content.ReadAsStringAsync();                    // Gelen veriyi değişkene atadık. (JsonData)              
            ViewBag.appUserCount = jsonData;

            var client4 = _httpClientFactory.CreateClient();                                          // Consume için istemci oluşturuldu.
            var responseMessage4 = await client.GetAsync("http://localhost:62391/api/DashboardWidgets/RoomCount");          // Belirtilen adrese istekte bulunuldu.
            var jsonData4 = await responseMessage.Content.ReadAsStringAsync();                    // Gelen veriyi değişkene atadık. (JsonData)              
            ViewBag.roomCount = jsonData;

            return View();
        }
    }
}
