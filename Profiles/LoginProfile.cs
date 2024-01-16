using AutoMapper;
using CoddingChallenge.DTOs;
using CoddingChallenge.Entities;

namespace CoddingChallenge.Profiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<Captain, LoginDTO>();
        }
    }
}
