using AutoMapper;
using APIExternaVibeCoding.DTOs;
using APIExternaVibeCoding.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIExternaVibeCoding.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalDataController : ControllerBase
    {
        private readonly IApiRepository _repo;
        private readonly IMapper _mapper; // Añadimos el campo para el mapper

        // Inyectamos tanto el repositorio como el mapper en el constructor
        public ExternalDataController(IApiRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetExternalUsersAsync();
            // Mapeamos la lista de entidades User a una lista de UserDto
            var usersDto = _mapper.Map<List<UserDto>>(users);
            return Ok(usersDto);
        }

        [HttpGet("posts")]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _repo.GetExternalPostsAsync();
            // Mapeamos la lista de entidades Post a una lista de PostDto
            var postsDto = _mapper.Map<List<PostDto>>(posts);
            return Ok(postsDto);
        }
    }
}