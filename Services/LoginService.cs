using AutoMapper;
using CoddingChallenge.Data;
using CoddingChallenge.DTOs;
using CoddingChallenge.Entities;
using CoddingChallenge.IServices;
using Microsoft.EntityFrameworkCore;

namespace CoddingChallenge.Services
{
    public class LoginService : ILoginService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public LoginService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<CaptainDTO> Login(LoginDTO loginDTO)
        {
            var captain = await _dataContext.Captains.FirstOrDefaultAsync(c => c.Username == loginDTO.Username) ?? throw new InvalidOperationException("Incorrect credentials!");

            if(VerifyPassword(captain.Password, loginDTO.Password)) 
            { 
                return new CaptainDTO(captain.Id, captain.Name);
            }

            throw new InvalidOperationException("Incorrect credentials!");
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string storedPassword, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedPassword);
        }

        public async Task<CaptainDTO> Register(RegisterDTO registerDTO)
        {
            var username = await _dataContext.Captains.Select(u => u.Username).FirstOrDefaultAsync(u => u == registerDTO.Username);

            if (username != null)
            {
                throw new InvalidOperationException("Username unavailable!");
            }

            var newCaptain = _mapper.Map<RegisterDTO, Captain>(registerDTO);
            newCaptain.Password = HashPassword(registerDTO.Password);

            await _dataContext.Captains.AddRangeAsync(newCaptain);
            await _dataContext.SaveChangesAsync();

            var teamId = await CreateTeam(newCaptain.Id, registerDTO.TeamName);
            await AddRobotsToTeam(teamId, registerDTO.Robots);

            return new CaptainDTO(newCaptain.Id, newCaptain.Name);
        }

        private async Task<int> CreateTeam(int captainId, string teamName)
        { 
            var newTeam = new Team(captainId, teamName);
            await _dataContext.Teams.AddRangeAsync(newTeam);
            await _dataContext.SaveChangesAsync();

            return newTeam.Id;
        }

        private async Task AddRobotsToTeam(int teamId, ICollection<string> robots)
        {
            foreach(var robot  in robots)
            {
                await _dataContext.Robots.AddAsync(new Robot(robot, teamId));
            }

            await _dataContext.SaveChangesAsync();
        }
    }
}
