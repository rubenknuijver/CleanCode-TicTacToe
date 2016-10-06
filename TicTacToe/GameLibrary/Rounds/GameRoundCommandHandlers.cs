namespace GameLibrary.Rounds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Messaging.Commands;

    public class GameRoundCommandHandlers
    {
        private readonly GameRound _round;

        public GameRoundCommandHandlers(GameRound round)
        {
            _round = round;
        }

        public void Handle(PlayerTakesTurn takeTurn)
        {
            _round.TakeTurn(takeTurn.Coordinate);
        }
    }
}
