namespace GameLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Serves as the base class for application-defined exceptions.</summary>
    /// <filterpriority>2</filterpriority>
    public class PlayerMaximumExcededException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerMaximumExcededException"/> class.
        /// </summary>
        /// <param name="maxPlayers">maximum number of playes allowed</param>
        public PlayerMaximumExcededException(int maxPlayers)
        {
            this.MaxPlayers = maxPlayers;
        }

        /// <summary>
        /// Gets the maximum number of playes allowed
        /// </summary>
        public int MaxPlayers
        {
            get;
        }
    }
}
