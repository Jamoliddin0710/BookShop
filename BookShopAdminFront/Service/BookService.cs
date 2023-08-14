using BookShopAdminFront.DTO.Book;
using BookShopAdminFront.Models.DTO.Book;
using BookShopAdminFront.Models.DTO.Buyer;
using BookShopFront.Models.ModelView;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Newtonsoft.Json;
using System.Text;

namespace BookShopAdminFront.Service
{
    public class BookService : HttpClientBase
    {
        public BookService(HttpClient httpClient) : base(httpClient) { }

        public async Task<BookDTO> AddBook(CreateBookDTO createBook)
        {
            var studentJson = JsonConvert.SerializeObject(createBook);
            var httpContent = new StringContent(studentJson, Encoding.UTF8, "application/json");

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7202/api/Admin_Book");
            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            httpRequest.Content = httpContent;

            var response = await httpClient.SendAsync(httpRequest);
            var authorDtoJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<BookDTO>(authorDtoJson);
            }

            return new BookDTO();
        }

        public async Task<BookDTO> UpdateBook(int bookId, UpdateBookDTO updateBook)
        {
            var authorJson = JsonConvert.SerializeObject(updateBook);
            var httpContent = new StringContent(authorJson, Encoding.UTF8, "application/json");

            var httpRequest = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:7202/api/Admin_Book/{bookId}");
            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            httpRequest.Content = httpContent;

            var response = await httpClient.SendAsync(httpRequest);
            var authorDtoJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<BookDTO>(authorDtoJson);
            }

            return new BookDTO();
        }


        public async Task DeleteBook(int bookId)
        {
            var url = $"https://localhost:7202/api/Admin_Book{bookId}";
            var httpRequest = new HttpRequestMessage(HttpMethod.Delete, url);
            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Book deletion failed.");
            }
        }

        public async Task<BookDTO> GetBookById(int bookId)
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7202/api/Admin_Book/api/Admin_Book/{bookId}");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var productJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<BookDTO>(productJson);
            }
            return new BookDTO();
        }
        public async Task<List<BookDTO>> GetAllBook()
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7202/api/Admin_Book");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var productJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<BookDTO>>(productJson);
            }
            return new List<BookDTO>();
        }

        public async Task<List<BookDTO>> GetGookByBookId(int bookId)
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7202/api/Admin_Book?genreId={bookId}");

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
                return JsonConvert.DeserializeObject<List<AuthorDTO>>(productJson);
            }
            return new List<AuthorDTO>();
        }

        public async Task<List<GenreDTO>> GetAllGenre()
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

        public async Task<List<PublisherDTO>> GetAllPublisher()
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7202/api/Admin_Publisher");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var genreJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<PublisherDTO>>(genreJson);
            }
            return new List<PublisherDTO>();
        }
    }
}
