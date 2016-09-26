namespace GameLibrary
{
    public class RoundCompletedEvent : IEvent
    {
        public RoundCompletedEvent(GameRound gameRound)
        {
            this.Round = gameRound;
        }

        public GameRound Round { get; }
    }
}