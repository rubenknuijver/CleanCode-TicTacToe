using GameLibrary.GamePlayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary
{
    public interface IPlayerTurn
    {
        DateTime Start { get; }

        Player Player { get; }

        void Take();
    }
}
