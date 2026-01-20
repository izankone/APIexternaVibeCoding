using APIExternaVibeCoding.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIExternaVibeCoding.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalDataController : ControllerBase
    {
        private readonly IApiRepository _repo;

        public ExternalDataController(IApiRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers() => Ok(await _repo.GetExternalUsersAsync());

        [HttpGet("posts")]
        public async Task<IActionResult> GetPosts() => Ok(await _repo.GetExternalPostsAsync());
    }
}