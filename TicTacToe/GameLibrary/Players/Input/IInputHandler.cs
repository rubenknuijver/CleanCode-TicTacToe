namespace GameLibrary.Players.Input
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IInputHandler<TEvent>
        where TEvent : IInputEvent
    {
        void Handle(TEvent inputEvent);
    }
}
