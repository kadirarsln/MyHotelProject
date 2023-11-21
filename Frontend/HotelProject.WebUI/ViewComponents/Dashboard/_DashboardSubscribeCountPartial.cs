using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //INSTAGRAM APİ

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/_kadirarsln"),
                Headers =
    {
        { "X-RapidAPI-Key", "675275f19dmsh96ac5cbc88c9371p1dec00jsn358dc5db05b9" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ResultInstagramFollowersDto resultInstagramFollowersDtos = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);

                ViewBag.instagramFollowers = resultInstagramFollowersDtos.followers;
                ViewBag.instagramFollowing = resultInstagramFollowersDtos.following;

            }


    //        //TWİTTER APİ

    //        var client2 = new HttpClient();
    //        var request2 = new HttpRequestMessage
    //        {
    //            Method = HttpMethod.Get,
    //            RequestUri = new Uri("https://twitter32.p.rapidapi.com/getProfile?username=firatresmihesap"),
    //            Headers =
    //{
    //    { "X-RapidAPI-Key", "675275f19dmsh96ac5cbc88c9371p1dec00jsn358dc5db05b9" },
    //    { "X-RapidAPI-Host", "twitter32.p.rapidapi.com" },
    //},
    //        };
    //        using (var response2 = await client2.SendAsync(request2))
    //        {
    //            response2.EnsureSuccessStatusCode();
    //            var body2 = await response2.Content.ReadAsStringAsync();
    //            ResultTwitterFollowersDto resultTwitterFollowersDtos = JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(body2);

    //            ViewBag.twitterFollowers = resultTwitterFollowersDtos.data.user_info.followers_count;
    //            ViewBag.twitterFollowing = resultTwitterFollowersDtos.data.user_info.favourites_count;
    //        }


            //LİNKLEDİN APİ

            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fkadir-%25C5%259Fehmus-arslan-29716420a%2F&include_skills=false"),
                Headers =
    {
        { "X-RapidAPI-Key", "675275f19dmsh96ac5cbc88c9371p1dec00jsn358dc5db05b9" },
        { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
                ResultLinkedinFollowersDto resultLinkedinFollowersDtos = JsonConvert.DeserializeObject<ResultLinkedinFollowersDto>(body3);

                ViewBag.linkedinFollowers = resultLinkedinFollowersDtos.data.followers_count;
            }
            return View();
        }
    }
}
