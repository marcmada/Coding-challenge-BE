using CoddingChallenge.Entities;

namespace CoddingChallenge.DTOs
{
    public class PlanetDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string StatusName { get; set; }
        public string CaptainName { get; set; }
        public ICollection<string> Robots { get; set; }
    }
}
