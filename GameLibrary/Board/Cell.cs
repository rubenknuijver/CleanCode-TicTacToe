namespace GameLibrary.Board
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GamePlayers;

    public class Cell : IEquatable<Cell>
    {
        public Cell(int score)
        {
            this.Score = score;
        }

        public int Score { get; }

        public Player Owner { get; set; } = null;

        public bool IsEmpty => this.Owner == null;

        public static bool operator ==(Cell first, Cell second)
        {
            if ((object)first == null) {
                return (object)second == null;
            }

            return first.Equals(second);
        }

        public static bool operator !=(Cell first, Cell second)
        {
            return !(first == second);
        }

        public static Cell Create(int score)
        {
            return new Cell(score);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Cell) {
                return this.Equals((Cell)obj);
            }

            return object.ReferenceEquals(this, obj);
        }

        /// <inheritdoc/>
        public bool Equals(Cell other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }

            if (ReferenceEquals(this, other)) {
                return true;
            }

            return this.Score.Equals(other.Score) && Equals(this.Owner, other.Owner);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked {
                int hashCode = 47;
                hashCode = (hashCode * 53) ^ this.Score.GetHashCode();

                if (this.Owner != null) {
                    hashCode = (hashCode * 53) ^ this.Owner.GetHashCode();
                }

                return hashCode;
            }
        }
    }
}
