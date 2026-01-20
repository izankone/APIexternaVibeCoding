using AutoMapper;
using APIExternaVibeCoding.Models;
using APIExternaVibeCoding.DTOs;

namespace APIExternaVibeCoding.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Definimos que User se mapea a UserDto y viceversa
            CreateMap<User, UserDto>().ReverseMap();
            // Definimos que Post se mapea a PostDto y viceversa
            CreateMap<Post, PostDto>().ReverseMap();
        }
    }
}