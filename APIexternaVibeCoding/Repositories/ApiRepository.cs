using APIExternaVibeCoding.Models;

namespace APIExternaVibeCoding.Repositories
{
    public class ApiRepository : IApiRepository
    {
        private readonly HttpClient _httpClient;

        public ApiRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetExternalUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<User>>("users") ?? new List<User>();
        }

        public async Task<List<Post>> GetExternalPostsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Post>>("posts") ?? new List<Post>();
        }
    }
}