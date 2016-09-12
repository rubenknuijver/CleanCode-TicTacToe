namespace GameLibrary.GamePlayers.Input
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class InputHandler<TEvent> : IInputHandler<TEvent>
        where TEvent : IInputEvent
    {
        /// <inheritdoc/>
        public void Handle(TEvent inputEvent)
        {
        }
    }
}
