namespace CoddingChallenge.Entities
{
    public class Robot
    {
        public Robot(string name, int? teamId)
        {
            Name = name;
            TeamId = teamId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? TeamId { get; set; }
        public Team Team { get; set; }
    }
}
