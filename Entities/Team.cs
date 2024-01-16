namespace CoddingChallenge.Entities
{
    public class Team
    {
        public Team(int? captainId, string teamName)
        {
            CaptainId = captainId;
            TeamName = teamName;
        }

        public int Id { get; set; }
        public string TeamName { get; set; }
        public int? CaptainId {  get; set; }
        public Captain Captain { get; set; }
        public ICollection<Robot> Robots { get; set; }
    }
}
