namespace GameLibrary.Messaging.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GameRoundWinnerAnnounced : Event
    {
        public GameRoundWinnerAnnounced(GameLibrary.Rounds.GameRound round)
        {
            this.Round = round;
        }

        public GameLibrary.Rounds.GameRound Round { get; }
    }
}
