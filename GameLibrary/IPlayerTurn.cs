namespace GameLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using GameLibrary.GamePlayers;

    public interface IPlayerTurn
    {
        DateTime Start { get; }

        Player Player { get; }

        void Take();
    }
}
