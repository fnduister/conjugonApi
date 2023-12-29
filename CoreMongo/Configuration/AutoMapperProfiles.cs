using AutoMapper;
using ConjugonApi.Models;

namespace ConjugonApi.Configuration
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Verb, VerbDTO>().ReverseMap();
        }
    }
}
