
using BookShopFront.Models.ModelView;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Newtonsoft.Json;

namespace BookShopBlazor.Service
{
    public class AuthorService : HttpClientBase
    {
        public AuthorService(HttpClient httpClient) : base(httpClient) { }
        public async Task<AuthorDTO> GetAuthorById(int authorId)
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7202/api/Admin_Author/{authorId}");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var productJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<AuthorDTO>(productJson);
            }
            return new AuthorDTO();
        }
        public async Task<List<AuthorDTO>> GetAllAuthor()
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7202/api/Admin_Author");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var productJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<AuthorDTO>> (productJson);
            }
            return new List<AuthorDTO>();
        }

        public async Task<List<BookDTO>> GetGookByAuthorId(int authorId)
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7202/api/Admin_Book?authorId={authorId}");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var productJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<BookDTO>>(productJson);
            }
            return new List<BookDTO>();
        }
    }
}
