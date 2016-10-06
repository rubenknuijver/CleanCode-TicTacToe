namespace GameLibrary.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;

    public class InMemoryBus : IBus
    {
        private static readonly IList<Type> _handlers = new List<Type>();
        private static readonly IDictionary<Type, dynamic> _handlerInstances = new Dictionary<Type, dynamic>();

        /// <inheritdoc/>
        public void RegisterHandler<T>()
        {
            InMemoryBus._handlers.Add(typeof(T));
        }

        /// <inheritdoc/>
        public void RegisterHandler<T>(T handler)
        {
            InMemoryBus._handlers.Add(typeof(T));
            InMemoryBus._handlerInstances.Add(typeof(T), handler);
        }

        /// <inheritdoc/>
        public void RaiseEvent<T>(T @event)
            where T : Event
        {
            this.InternalSend(@event);
        }

        public void Send<T>(T command)
             where T : ICommand
        {
            this.InternalSend(command);
        }

        private void InternalSend<T>(T message)
            where T : IMessage
        {
            var messageType = message.GetType();
            var openInterface = typeof(IHandler<>);
            var closedInterface = openInterface.MakeGenericType(messageType);
            var handlersToNotify = from h in InMemoryBus._handlers
                                   where closedInterface.IsAssignableFrom(h)
                                   select h;

            foreach (var h in handlersToNotify) {
                dynamic handlerInstance = InMemoryBus._handlerInstances.ContainsKey(h)
                    ? InMemoryBus._handlerInstances[h]
                    : Activator.CreateInstance(h);

                if (h.GetCustomAttribute<AsyncEventHandlerAttribute>() == null) {
                    handlerInstance.Handle(message);
                }
                else {
                    ThreadPool.QueueUserWorkItem(x => handlerInstance.Handle(message));
                }
            }
        }
    }
}
