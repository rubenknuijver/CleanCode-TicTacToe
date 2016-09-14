namespace GameLibrary.Board
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GamePlayers;
    using Styx.Diagnostics;

    /// <summary>
    /// Cells are squars or spaces on the GameBoard
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("Empty? = {IsEmpty}")]
    public class Cell : IEquatable<Cell>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="identifier">unique value to identify the cell</param>
        protected Cell(int identifier)
        {
            this.Identifier = identifier;
        }

        /// <summary>
        /// Gets the unique value to identify the cell
        /// </summary>
        public int Identifier { get; }

        public Player Owner { get; set; } = null;

        /// <summary>
        /// Gets a value indicating whether the cell is empty
        /// </summary>
        public bool IsEmpty => this.Owner == null;

        /// <summary>
        /// Compare the equality betreen two Cells
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>true if Cells are equal</returns>
        public static bool operator ==(Cell first, Cell second)
        {
            if ((object)first == null) {
                return (object)second == null;
            }

            return first.Equals(second);
        }

        /// <summary>
        /// Compare inquality between two Cells
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>true if Cells are not equal</returns>
        public static bool operator !=(Cell first, Cell second)
        {
            return !(first == second);
        }

        /// <summary>
        /// Factory method for creating a new Cell
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
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

            return this.Identifier.Equals(other.Identifier) && Equals(this.Owner, other.Owner);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked {
                int hashCode = 47;
                hashCode = (hashCode * 53) ^ this.Identifier.GetHashCode();

                if (this.Owner != null) {
                    hashCode = (hashCode * 53) ^ this.Owner.GetHashCode();
                }

                return hashCode;
            }
        }
    }
}
