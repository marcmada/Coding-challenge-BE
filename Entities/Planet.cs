namespace CoddingChallenge.Entities
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int? StatusId { get; set; }
        public Status Status { get; set; }
        public int NumberOfRobots { get; set; }
        public int? TeamId { get; set; }
        public Team Team { get; set; }
    }
}
