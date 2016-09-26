namespace GameLibrary.Players
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Styx.Diagnostics;

    /// <summary>Supports all classes in the .NET Framework class hierarchy and provides low-level services to derived classes.
    /// This is the ultimate base class of all classes in the .NET Framework;
    /// it is the root of the type hierarchy.To browse the .NET Framework source code for this type, see the Reference Source.
    /// </summary>
    /// <filterpriority>1</filterpriority>
    public abstract class Player : IEquatable<Player>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// Players should always have a Unique name for display
        /// </summary>
        /// <param name="name">Name of the player</param>
        protected Player(string name)
        {
            Argument.ThrowIfNullOrEmpty(name, nameof(name));

            this.Name = name;
        }

        /// <summary>
        /// Gets the Player Name
        /// </summary>
        public string Name
        {
            get;
        }

        /// <summary>
        /// Gets or sets something like an Avatar
        /// </summary>
        public PlayerSymbol Symbol
        {
            get;
            set;
        }

        /// <summary>
        /// Compare if players are Equal
        /// </summary>
        /// <param name="first">First PLayer to compare</param>
        /// <param name="second">Second PLayer to compare</param>
        /// <returns>true if equal</returns>
        public static bool operator ==(Player first, Player second)
        {
            if ((object)first == null) {
                return (object)second == null;
            }

            return first.Equals(second);
        }

        /// <summary>
        /// Compare if players are Not Equal
        /// </summary>
        /// <param name="first">First PLayer to compare</param>
        /// <param name="second">Second PLayer to compare</param>
        /// <returns>true if not equal</returns>
        public static bool operator !=(Player first, Player second)
        {
            return !(first == second);
        }

        public virtual void Update()
        {
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked {
                return this.GetType()
                    .GetHashCode() * 31 ^ this.Name?.GetHashCode() ?? 0;
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Player) {
                return this.Equals((Player)obj);
            }

            return object.ReferenceEquals(this, obj);
        }

        /// <inheritdoc/>
        public bool Equals(Player other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }

            if (ReferenceEquals(this, other)) {
                return true;
            }

            return Equals(this.Name, other.Name); // && this.Mark.Equals(other.Mark);
        }
    }
}
