using APIExternaVibeCoding.Models;
using APIExternaVibeCoding.DTOs; // <--- Añade esto
using System.Net.Http.Json;

namespace APIExternaVibeCoding.Repositories
{
    public class ApiRepository : IApiRepository
    {
        private readonly HttpClient _httpClient;
        public ApiRepository(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<List<UserDto>> GetExternalUsersAsync()
        {
            // Cambia <List<User>> por <List<UserDto>>
            return await _httpClient.GetFromJsonAsync<List<UserDto>>("users") ?? new();
        }

        public async Task<List<PostDto>> GetExternalPostsAsync()
        {
            // Cambia <List<Post>> por <List<PostDto>>
            return await _httpClient.GetFromJsonAsync<List<PostDto>>("posts") ?? new();
        }
    }
}