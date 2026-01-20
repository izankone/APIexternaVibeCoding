using APIExternaVibeCoding.Models;

namespace APIExternaVibeCoding.Repositories
{
    public interface IApiRepository
    {
        Task<List<User>> GetExternalUsersAsync();
        Task<List<Post>> GetExternalPostsAsync();
    }
}