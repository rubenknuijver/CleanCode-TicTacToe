namespace GameLibrary.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GenericEventHandler<T> : IHandler<T>
        where T : IEvent
    {

        private readonly Action<T> _handler;

        public GenericEventHandler(Action<T> handler)
        {
            if (handler == null) {
                throw new ArgumentNullException(nameof(handler), $"{nameof(handler)} is null.");
            }

            this._handler = handler;
        }

        public void Handle(T @event)
        {
            this._handler(@event);
        }
    }
}
