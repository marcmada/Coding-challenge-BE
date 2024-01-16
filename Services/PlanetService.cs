using AutoMapper;
using CoddingChallenge.Data;
using CoddingChallenge.DTOs;
using CoddingChallenge.Entities;
using CoddingChallenge.IServices;
using Microsoft.EntityFrameworkCore;

namespace CoddingChallenge.Services
{
    public class PlanetService : IPlanetService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public PlanetService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<List<PlanetDetailsDTO>> GetPlanets()
        {
            var planets = await _dataContext.Planets
                .Include(p => p.Status)
                .Include(p => p.Team).ThenInclude(t => t.Captain)
                .Include(p => p.Team).ThenInclude(t => t.Robots)
                .ToListAsync();

            return _mapper.Map<List<Planet>, List<PlanetDetailsDTO>>(planets);
        }

        public async Task<PlanetDetailsDTO> GetPlanetById(int id)
        {
            return _mapper.Map<Planet, PlanetDetailsDTO>(await _dataContext.Planets
                .Include(p => p.Status)
                .Include(p => p.Team).ThenInclude(t => t.Captain)
                .Include(p => p.Team).ThenInclude(t => t.Robots)
                .FirstOrDefaultAsync(p => p.Id == id));
        }
    }
}
