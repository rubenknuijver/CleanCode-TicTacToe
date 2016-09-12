namespace GameLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GamePlayers;

    public static class ExceptionFactory
    {
        public static Exception CoordinateOutOfBound(string name)
        {
            return new ArgumentOutOfRangeException(name);
        }

        public static ApplicationException PlayerMaximum(int maxPlayers)
        {
            return new PlayerMaximumExcededException(maxPlayers);
        }

        public static ApplicationException DuplicatePlayer(Player player)
        {
            return new DuplicatePlayerException(player);
        }
    }
}
