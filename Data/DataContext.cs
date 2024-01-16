using CoddingChallenge.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoddingChallenge.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Planet> Planets { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Captain> Captains { get; set; }
        public DbSet<Robot> Robots { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
