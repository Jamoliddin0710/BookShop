using Blazored.LocalStorage;

namespace BookShopAdminFront.Service
{
    public class IdentityService
    {
        private readonly ILocalStorageService _localStorage;
        public IdentityService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task<string?> GetTokenAsync()
        {
            return await _localStorage.GetItemAsync<string>("token");
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            string? token = await  GetTokenAsync();
            return !string.IsNullOrEmpty(token);
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("token");
        }
    }
}
