using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.GamePlayers.Input
{
    public interface IInputHandler<TEvent> where TEvent : IInputEvent
    {
        void Handle(TEvent inputEvent);
    }
}
