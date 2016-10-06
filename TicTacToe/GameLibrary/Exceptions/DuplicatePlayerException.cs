namespace GameLibrary
{
    using System;
    using System.Runtime.Serialization;
    

    /// <summary>Serves as the base class for application-defined exceptions.</summary>
    /// <filterpriority>2</filterpriority>
    public class DuplicatePlayerException : ApplicationException, ISerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicatePlayerException"/> class.
        /// </summary>
        /// <param name="player">the player that could be duplicate</param>
        public DuplicatePlayerException(Players.Player player)
        {
            this.Player = player;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicatePlayerException"/> class.
        /// This constructor is used by the Serizalizer
        /// </summary>
        /// <param name="info"><see cref="SerializationInfo"/></param>
        /// <param name="context"><see cref="StreamingContext"/></param>
        protected DuplicatePlayerException(SerializationInfo info, StreamingContext context)
        {
            if (info == null) {
                return;
            }

            this.Player = (Players.Player)info.GetValue("Player", typeof(Players.Player));
        }

        /// <summary>
        /// Gets the player that could be duplicate
        /// </summary>
        public Players.Player Player
        {
            get;
        }

        /// <inheritdoc/>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) {
                return;
            }

            info.AddValue("Player", this.Player);
        }
    }
}
