using BookShopAdminFront.Models.DTO.Author;
using BookShopFront.Models.ModelView;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Newtonsoft.Json;
using System.Text;
using BookShopAdminFront.Models.DTO;
using BookShopAdminFront.Models.DTO.Genre;

namespace BookShopAdminFront.Service
{
    public class GenreService : HttpClientBase
    {
        public GenreService(HttpClient httpClient) : base(httpClient) { }

        public async Task<GenreDTO> Add(CreateGenreDTO createGenreDTO)
        {
            var genreJson = JsonConvert.SerializeObject(createGenreDTO);
            var httpContent = new StringContent(genreJson, Encoding.UTF8, "application/json");

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7202/api/Admin_Genre");
            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            httpRequest.Content = httpContent;

            var response = await httpClient.SendAsync(httpRequest);
            var GenreDTOJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GenreDTO>(GenreDTOJson);
            }

            return new GenreDTO();
        }

        public async Task<GenreDTO> Update(int genreId, UpdateGenreDTO updateGenreDTO)
        {
            var genreJson = JsonConvert.SerializeObject(updateGenreDTO);
            var httpContent = new StringContent(genreJson, Encoding.UTF8, "application/json");

            var httpRequest = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:7202/api/Admin_Genre/{genreId}");
            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            httpRequest.Content = httpContent;

            var response = await httpClient.SendAsync(httpRequest);
            var GenreDTOJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GenreDTO>(GenreDTOJson);
            }

            return new GenreDTO();
        }


        public async Task Delete(int genreId)
        {
            var url = $"https://localhost:7202/api/Admin_Genre/{genreId}";
            var httpRequest = new HttpRequestMessage(HttpMethod.Delete, url);
            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Genre deletion failed.");
            }
        }

        public async Task<GenreDTO> GetAuthorById(int genreId)
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7202/api/Admin_Author/{genreId}");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var genreJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GenreDTO>(genreJson);
            }
            return new GenreDTO();
        }
        public async Task<List<GenreDTO>> GetAllAuthor()
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7202/api/Admin_Genre");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var genreJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<GenreDTO>>(genreJson);
            }
            return new List<GenreDTO>();
        }

        public async Task<List<GenreDTO>> GetGookByAuthorId(int genreId)
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7202/api/Admin_Genre/{genreId}");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var genreJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<GenreDTO>>(genreJson);
            }
            return new List<GenreDTO>();
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
