namespace GameLibrary.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IEventRaiser
    {
        /// <summary>
        /// Raise an Event on the Bus that will be handled elsewhere
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="event"></param>
        void RaiseEvent<T>(T @event)
            where T : Event;
    }
}
