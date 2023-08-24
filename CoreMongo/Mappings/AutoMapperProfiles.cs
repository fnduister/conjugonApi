using AutoMapper;
using ConjugonApi.DTOs;
using ConjugonApi.Models;
using ConjugonApi.Models.Domain;
using CoreMongo.Models.DTOs;

namespace ConjugonApi.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() { 
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Verb, VerbDTO>().ReverseMap();
        }
    }
}
