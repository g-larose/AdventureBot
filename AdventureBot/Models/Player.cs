using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBot.Models
{
    public class Player
    {
        public int Id { get; set; }
        public Guid PlayerId { get; set; }
        public string? Name { get; set; }
        public uint Xp { get; set; }
        public double Luck { get; set; }
        public Profession Profession { get; set; }
        public Race Race { get; set; }
        public ICollection<Item>? Items { get; set; }
        public ICollection<Ability>? Abilities { get; set; }
    }
}
