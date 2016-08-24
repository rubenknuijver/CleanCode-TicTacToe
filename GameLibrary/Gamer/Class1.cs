using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Gamer
{
    public interface IInputHandler<TEvent> where TEvent : IInputEvent
    {
        void Handle(TEvent inputEvent);
    }

    public class InputHandler<TEvent> : IInputHandler<TEvent> where TEvent : IInputEvent
    {
        public void Handle(TEvent inputEvent)
        {

        }
    }
}
