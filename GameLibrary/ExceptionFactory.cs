using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public static class ExceptionFactory
    {
        public static Exception CoordinateOutOfBound(string name)
        {
            return new ArgumentOutOfRangeException(name);
        }

        public static ApplicationException PlayerMaximum(int maxPlayers)
        {
            return new PlayerMaximumException(maxPlayers);
        }

        public static ApplicationException DuplicatePlayer(GameLibrary.Gamer.Player player)
        {
            return new DuplicatePlayerException(player);
        }
    }
}
