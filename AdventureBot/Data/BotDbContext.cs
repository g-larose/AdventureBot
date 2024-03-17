using Microsoft.EntityFrameworkCore;

namespace AdventureBot.Data
{
    public class BotDbContext: DbContext
    {

        public BotDbContext() { }

        public BotDbContext(DbContextOptions options) : base(options) { }

    }
}
