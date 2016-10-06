namespace GameLibrary.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public class HandlerBase
    {
        public HandlerBase(GameLibrary.Messaging.IBus eventBus)
        {
            EventBus = eventBus;
        }

        protected GameLibrary.Messaging.IBus EventBus { get; }
    }

    public interface ICommandBus
    {
        /// <summary>
        /// Send command to corresponding commandHandler
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        ICommandBus Send<T>(T command) where T : ICommand;
    }

    /// <summary>
    /// Command is used to decouple the aggregate service.
    /// One command MUST be handle by one method.
    /// </summary>
    public interface ICommand:IMessage
    {
    }

    public interface ICommandHandler<T>
        where T : ICommand
    {
        void Execute(T command);
    }

    public class CommandBus : ICommandBus
    {
        private IDictionary<Type, Type> _handlers;

        public ICommandBus Send<T>(T command)
            where T : ICommand
        {
            var handler = GetHandler<T>();
            handler.Execute(command);
            return this;
        }

        public ICommandHandler<T> GetHandler<T>()
            where T : ICommand
        {
            Type handler;
            if (!_handlers.TryGetValue(typeof(T), out handler)) {
                throw new UnregisteredDomainCommandException("no handler registered for command: " + typeof(T));
            }

            return (ICommandHandler<T>)Activator.CreateInstance(handler);
        }
    }

    public class UnregisteredDomainCommandException : Exception
    {
        public UnregisteredDomainCommandException(string message)
            : base(message)
        {
        }
    }

    public static class DelegateAdjuster
    {
        public static Action<BaseT> CastArgument<BaseT, DerivedT>(Expression<Action<DerivedT>> source)
            where DerivedT : BaseT
        {
            if (typeof(DerivedT) == typeof(BaseT)) {
                return (Action<BaseT>)((Delegate)source.Compile());
            }

            ParameterExpression sourceParameter = Expression.Parameter(typeof(BaseT), "source");
            var result = Expression.Lambda<Action<BaseT>>(
                Expression.Invoke(
                    source,
                    Expression.Convert(sourceParameter, typeof(DerivedT))),
                sourceParameter
                );

            return result.Compile();
        }
    }
}
