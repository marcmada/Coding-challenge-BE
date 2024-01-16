using AutoMapper;
using CoddingChallenge.DTOs;
using CoddingChallenge.Entities;

namespace CoddingChallenge.Profiles
{
    public class RegisterProfile : Profile
    {
        public RegisterProfile()
        {
            CreateMap<Captain, RegisterDTO>()
                .ReverseMap();
        }
    }
}
