using APIExternaVibeCoding.DTOs;
namespace APIExternaVibeCoding.Repositories
{
    public interface IApiRepository
{
    Task<List<UserDto>> GetExternalUsersAsync();
    Task<List<PostDto>> GetExternalPostsAsync();
}
}