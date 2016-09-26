using System;

namespace GameLibrary.Board
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Styx.Diagnostics;

    /// <summary>
    /// Cells are squares or spaces on the GameBoard
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("Empty? = {IsEmpty}")]
    public class Cell : IEquatable<Cell>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="coordinate">unique value to identify the cell</param>
        protected Cell(BoardCoordinate coordinate)
        {
            this.Coordinate = coordinate;
        }

        /// <summary>
        /// Gets the unique value to identify the cell
        /// </summary>
        public BoardCoordinate Coordinate { get; }

        /// <summary>
        /// Gets or sets the cells occupant
        /// </summary>
        public Players.Player Occupant { get; set; } = null;

        /// <summary>
        /// Gets a value indicating whether the cell is empty
        /// </summary>
        public bool IsEmpty => this.Occupant == null;

        /// <summary>
        /// Compare the equality between two Cells
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
        /// Compare inequality between two Cells
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>true if Cells are not equal</returns>
        public static bool operator !=(Cell first, Cell second)
        {
            return !(first == second);
        }

        public void Reset()
        {
           this.Occupant = null;
        }

        /// <summary>
        /// Factory method for creating a new Cell
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public static Cell Create(BoardCoordinate coordinate)
        {
            return new Cell(coordinate);
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

            return this.Coordinate.Equals(other.Coordinate) && Equals(this.Occupant, other.Occupant);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked {
                int hashCode = 47;
                hashCode = (hashCode * 53) ^ this.Coordinate.GetHashCode();

                if (this.Occupant != null) {
                    hashCode = (hashCode * 53) ^ this.Occupant.GetHashCode();
                }

                return hashCode;
            }
        }
    }
}
