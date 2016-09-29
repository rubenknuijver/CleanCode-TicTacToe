namespace GameLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IBus
    {
        /// <summary>
        /// Raise an Event on the Bus that will be handled elsewhere
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="event"></param>
        void RaiseEvent<T>(T @event)
            where T : IEvent;

        /// <summary>
        /// Register Handlers for a specific Event
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void RegisterHandler<T>();

        /// <summary>
        /// Register Single instance Handler
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler"></param>
        void RegisterHandler<T>(T handler);
    }

    public class InMemoryBus : IBus
    {
        private static readonly IList<Type> _handlers = new List<Type>();
        private static readonly IDictionary<Type, dynamic> _handlerInstances = new Dictionary<Type, dynamic>();

        /// <inheritdoc/>
        void IBus.RegisterHandler<T>()
        {
            _handlers.Add(typeof(T));
        }

        /// <inheritdoc/>
        void IBus.RegisterHandler<T>(T handler)
        {
            _handlers.Add(typeof(T));
            _handlerInstances.Add(typeof(T), handler);
        }

        /// <inheritdoc/>
        void IBus.RaiseEvent<T>(T @event)
        {
            this.Send(@event);
        }

        private void Send<T>(T message)
            where T : IEvent
        {
            var messageType = message.GetType();
            var openInterface = typeof(IHandler<>);
            var closedInterface = openInterface.MakeGenericType(messageType);
            var handlersToNotify = from h in _handlers
                                   where closedInterface.IsAssignableFrom(h)
                                   select h;

            foreach (var h in handlersToNotify) {
                dynamic handlerInstance = _handlerInstances.ContainsKey(h)
                    ? _handlerInstances[h]
                    : Activator.CreateInstance(h);

                ThreadPool.QueueUserWorkItem(x => handlerInstance.Handle(message));
            }
        }
    }

    public interface IEvent
    {
    }

    public interface IHandler<T>
        where T : IEvent
    {
        /// <summary>
        /// Handle the Event
        /// </summary>
        /// <param name="@event"></param>
        void Handle(T @event);
    }
}
