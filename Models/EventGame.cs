using Microsoft.EntityFrameworkCore;
namespace BoardLove.Models
{
    public class EventGame
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Date { get; set; }
        public int[]? ParticipainsId { get; set; }
        public string? Place {get;set;}

        
    }
    class EventGameDb : DbContext
        {
            public EventGameDb(DbContextOptions options) : base(options) { }
            public DbSet<EventGame> EventGames { get; set; } = null!;
        }
}
