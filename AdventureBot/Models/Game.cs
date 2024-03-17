using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBot.Models
{
    public class Game
    {
        public int Id { get; set; }
        public Guid GameId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int MaxPlayers { get; set; } = 4;
        public Player[]? Players { get; set; }
    }
}
