using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.GamePlayers
{
    public abstract class Player : IEquatable<Player>
    {
        public string Name { get; }

        public MarkType Mark { get; set; }

        public Player(string name)
        {
            this.Name = name;
        }

        public override int GetHashCode()
        {
            unchecked {
                return GetType()
                    .GetHashCode() * 31 ^ Name?.GetHashCode() ?? 0;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Player)
                return Equals((Player)obj);

            return object.ReferenceEquals(this, obj);
        }

        public static bool operator ==(Player first, Player second)
        {
            if ((object)first == null)
                return (object)second == null;

            return first.Equals(second);
        }

        public static bool operator !=(Player first, Player second)
        {
            return !(first == second);
        }

        public bool Equals(Player other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Equals(this.Name, other.Name);// && this.Mark.Equals(other.Mark);
        }
    }
}
