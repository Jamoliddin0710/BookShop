using Entities.DTO.User;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Newtonsoft.Json;
using System.Text;

namespace BookShopAdminFront.Service
{
    public class AuthService : HttpClientBase
    {
        public AuthService(HttpClient httpClient) : base(httpClient)
        {
        }
        public async Task<UserAuthInfo> AddAuthor(UserCredentials userCredentials)
        {
            var queryURL = $"PhoneNumber={userCredentials.PhoneNumber}&Password={userCredentials.Password}";
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7202/api/Admin_Account/sign-in?" + queryURL);
            Console.WriteLine("So'rov keldi");
            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            var response = await httpClient.SendAsync(httpRequest);
            var authorDtoJson = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"So'rov keldi Context: {response.Content} StatusCode: {response.StatusCode}");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("So'rov muvaffaqiyatli");
                return JsonConvert.DeserializeObject<UserAuthInfo>(authorDtoJson);
            }

            return new UserAuthInfo();
        }
    }
}
