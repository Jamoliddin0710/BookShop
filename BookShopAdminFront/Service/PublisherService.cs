using BookShopFront.Models.ModelView;
using Entities.DTO.Publisher;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace BookShopAdminFront.Service
{
    public class PublisherService : HttpClientBase
    {

        public PublisherService(HttpClient httpClient) : base(httpClient) { }

        public async Task<PublisherDTO> Add(CreatePublisherDTO createPublisher)
        {
            var publisherJson = JsonConvert.SerializeObject(createPublisher);
            var httpContent = new StringContent(publisherJson, Encoding.UTF8, "application/json");

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7202/api/Admin_Genre");
            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            httpRequest.Content = httpContent;

            var response = await httpClient.SendAsync(httpRequest);
            var GenreDTOJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PublisherDTO>(GenreDTOJson);
            }

            return new PublisherDTO();
        }

        public async Task<PublisherDTO> Update(int publisherId, UpdatePublisherDTO updatePublisher)
        {
            var publisherJson = JsonConvert.SerializeObject(updatePublisher);
            var httpContent = new StringContent(publisherJson, Encoding.UTF8, "application/json");

            var httpRequest = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:7202/api/Admin_Publisher/{publisherId}");
            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            httpRequest.Content = httpContent;

            var response = await httpClient.SendAsync(httpRequest);
            var GenreDTOJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PublisherDTO>(GenreDTOJson);
            }

            return new PublisherDTO();
        }


        public async Task Delete(int publisherId)
        {
            var url = $"https://localhost:7202/api/Admin_Publisher/{publisherId}";
            var httpRequest = new HttpRequestMessage(HttpMethod.Delete, url);
            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Genre deletion failed.");
            }
        }

        public async Task<PublisherDTO> GetAuthorById(int publisherId)
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7202/api/Admin_Author/{publisherId}");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var publisherJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PublisherDTO>(publisherJson);
            }
            return new PublisherDTO();
        }
        public async Task<List<PublisherDTO>> GetAllAuthor()
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7202/api/Admin_Genre");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var genreJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<PublisherDTO>>(genreJson);
            }
            return new List<PublisherDTO>();
        }

        public async Task<List<PublisherDTO>> GetGookByAuthorId(int publisherId)
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7202/api/Admin_Genre/{publisherId}");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var genreJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<PublisherDTO>>(genreJson);
            }
            return new List<PublisherDTO>();
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
