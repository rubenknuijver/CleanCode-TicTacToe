namespace GameLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TurnChangedEvent : IEvent
    {
        public TurnChangedEvent(GameRound round)
        {
            this.Round = round;
        }

        public GameRound Round { get; }
    }
}
