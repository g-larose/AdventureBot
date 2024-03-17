using AdventureBot.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureBot.Data
{
    public class BotDbContext: DbContext
    {
        public DbSet<Player> Players { get; set; }
        public BotDbContext() { }

        public BotDbContext(DbContextOptions options) : base(options) { }

    }
}
