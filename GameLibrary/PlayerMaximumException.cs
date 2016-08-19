using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary
{
    public class PlayerMaximumException : ApplicationException
    {
        public int MaxPlayers
        {
            get;
        }

        public PlayerMaximumException(int maxPlayers)
        {
            MaxPlayers = maxPlayers;
        }
    }
}
