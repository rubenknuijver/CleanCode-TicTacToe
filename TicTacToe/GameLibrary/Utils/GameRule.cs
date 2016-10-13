namespace GameLibrary.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Board;
    using Rounds;

    public abstract class GameRule
    {
        public abstract void Handle(GameBoard board, GameRound round);
    }
}
