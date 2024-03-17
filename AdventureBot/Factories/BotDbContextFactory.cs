using AdventureBot.Data;
using AdventureBot.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdventureBot.Factories
{
    public class BotDbContextFactory : IDesignTimeDbContextFactory<BotDbContext>
    {
        public BotDbContext CreateDbContext(string[] args)
        {
            var jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
            var json = File.ReadAllText(jsonFile);
            var connStr = JsonSerializer.Deserialize<ConfigJson>(json)?.ConnectionString;
            var options = new DbContextOptionsBuilder<BotDbContext>();
            options.UseNpgsql(connStr);

            return new BotDbContext(options.Options);
        }
    }
}
