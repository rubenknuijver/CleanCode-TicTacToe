namespace GameLibrary.Messaging.Events
{
    public class GameRoundCompleted : Event
    {
        public GameRoundCompleted(GameLibrary.Rounds.GameRound gameRound)
        {
            this.Round = gameRound;
        }

        public GameLibrary.Rounds.GameRound Round { get; }
    }
}