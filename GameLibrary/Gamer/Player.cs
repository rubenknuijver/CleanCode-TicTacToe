using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Gamer
{
    public abstract class Player
    {
        public string Name { get; }
        public MarkType Mark { get; set; }

        public Player(string name)
        {
            this.Name = name;
        }

        public override int GetHashCode()
        {
            return typeof(Player).GetHashCode() * 31 ^ Name?.GetHashCode() ?? 0;
        }
    }
}
