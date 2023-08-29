
using BookShopAdminFront.Service;
using BookShopFront.DTO.Author;
using BookShopFront.Models.ModelView;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Newtonsoft.Json;
using System.Text;

namespace BookShopBlazor.Service
{
    public class AuthorService : HttpClientBase
    {
        public AuthorService(HttpClient httpClient) : base(httpClient) { }

        public async Task<AuthorDTO> AddAuthor(CreateAuthorDTO createStudent)
        {
            var studentJson = JsonConvert.SerializeObject(createStudent);
            var httpContent = new StringContent(studentJson, Encoding.UTF8, "application/json");

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7202/api/Admin_Author");
            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            httpRequest.Content = httpContent;

            var response = await httpClient.SendAsync(httpRequest);
            var studentDtoJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<AuthorDTO>(studentDtoJson);
            }

            return new AuthorDTO();
        }

        public async Task<AuthorDTO> UpdateAuthor(int authorId, UpdateAuthorDTO updateAuthor)
        {
            var authorJson = JsonConvert.SerializeObject(updateAuthor);
            var httpContent = new StringContent(authorJson, Encoding.UTF8, "application/json");

            var httpRequest = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:7202/api/Admin_Author/{authorId}");
            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            httpRequest.Content = httpContent;

            var response = await httpClient.SendAsync(httpRequest);
            var authorDtoJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<AuthorDTO>(authorDtoJson);
            }

            return new AuthorDTO();
        }


        public async Task DeleteAuthor(int authorId)
        {
            var url = $"https://localhost:7202/api/Admin_Author?authorId={authorId}";
            var httpRequest = new HttpRequestMessage(HttpMethod.Delete, url);
            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Student deletion failed.");
            }
        }

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

        public async Task<ImageDTO> GetImage(int imageId)
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7202/api/Files/5");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var imageJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ImageDTO>(imageJson);
            }
            return new ImageDTO();
        }
    }
}
