namespace GameLibrary.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GenericEventHandler<T> : GameLibrary.Messaging.IHandler<T>
        where T : Event
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

    public class AsyncGenericEventHandler<T> : GameLibrary.Messaging.IHandler<T>
        where T : Event
    {
        private readonly Action<T> _handler;

        public AsyncGenericEventHandler(Action<T> handler)
        {
            if (handler == null) {
                throw new ArgumentNullException(nameof(handler), $"{nameof(handler)} is null.");
            }

            this._handler = handler;
        }

        public void Handle(T @event)
        {
            var task = Task.Run(() => this._handler(@event));
            task.Wait();
        }
    }

    [System.AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class AsyncEventHandlerAttribute : Attribute
    {
    }
}
