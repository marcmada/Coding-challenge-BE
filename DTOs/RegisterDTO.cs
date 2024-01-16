using CoddingChallenge.Entities;

namespace CoddingChallenge.DTOs
{
    public class RegisterDTO
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string TeamName { get; set; }
        public ICollection<string> Robots { get; set; }
    }
}
