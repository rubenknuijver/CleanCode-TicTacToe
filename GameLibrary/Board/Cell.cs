using GameLibrary.GamePlayers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Board
{
    public class Cell : IEquatable<Cell>
    {
        public int Score { get; }

        public Player Owner { get; set; } = null;

        public bool IsEmpty => Owner == null;

        public Cell(int score)
        {
            Score = score;
        }

        public static Cell Create(int score)
        {
            return new Cell(score);
        }

        public override bool Equals(object obj)
        {
            if (obj is Cell)
                return Equals((Cell)obj);

            return object.ReferenceEquals(this, obj);
        }

        public static bool operator ==(Cell first, Cell second)
        {
            if ((object)first == null)
                return (object)second == null;

            return first.Equals(second);
        }

        public static bool operator !=(Cell first, Cell second)
        {
            return !(first == second);
        }

        public bool Equals(Cell other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return this.Score.Equals(other.Score) && Equals(this.Owner, other.Owner);
        }

        public override int GetHashCode()
        {
            unchecked {
                int hashCode = 47;
                hashCode = (hashCode * 53) ^ this.Score.GetHashCode();

                if (this.Owner != null)
                    hashCode = (hashCode * 53) ^ this.Owner.GetHashCode();

                return hashCode;
            }
        }
    }
}
