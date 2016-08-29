using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.GamePlayers.Input
{

    public class InputHandler<TEvent> : IInputHandler<TEvent> where TEvent : IInputEvent
    {
        public void Handle(TEvent inputEvent)
        {

        }
    }
}
