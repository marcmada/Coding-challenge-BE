using CoddingChallenge.DTOs;

namespace CoddingChallenge.IServices
{
    public interface ILoginService
    {
        Task<CaptainDTO> Login(LoginDTO loginDTO);
        Task<CaptainDTO> Register(RegisterDTO registerDTO);
    }
}
