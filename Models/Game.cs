using Microsoft.EntityFrameworkCore;
namespace BoardLove.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PlayingTime { get; set; }
        public int? MinPlayers { get; set; }
        public int? MaxPlayers { get; set; }

        
    }
    class GameDb : DbContext
        {
            public GameDb(DbContextOptions options) : base(options) { }
            public DbSet<Game> Games { get; set; } = null!;
        }
}
