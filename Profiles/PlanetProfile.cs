using AutoMapper;
using CoddingChallenge.DTOs;
using CoddingChallenge.Entities;

namespace CoddingChallenge.Profiles
{
    public class PlanetProfile : Profile
    {
        public PlanetProfile()
        {
            CreateMap<Planet, PlanetDetailsDTO>()
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src =>
                                   src.Status.StatusName))
                .ForMember(dest => dest.CaptainName, opt => opt.MapFrom(src =>
                                   src.Team.Captain.Name))
                .ForMember(dest => dest.Robots, opt => opt.MapFrom(src =>
                                   GetRobotsNames(src.Team.Robots)));
        }

        private ICollection<string> GetRobotsNames(ICollection<Robot> robots)
        {
            return robots.Select(r => r.Name).ToList();
        }
    }
}
