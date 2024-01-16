using CoddingChallenge.DTOs;
using CoddingChallenge.Entities;

namespace CoddingChallenge.IServices
{
    public interface IPlanetService
    {
        Task<List<PlanetDetailsDTO>> GetPlanets();
        Task<PlanetDetailsDTO> GetPlanetById(int id);
    }
}
