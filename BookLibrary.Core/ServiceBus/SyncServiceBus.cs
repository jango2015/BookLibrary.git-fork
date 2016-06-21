using Castle.Windsor;

namespace BookLibrary.Core.ServiceBus
{
    public class SyncServiceBus:IServiceBus
    {
        private readonly IWindsorContainer _container;

        public SyncServiceBus(IWindsorContainer container)
        {
            _container = container;
        }

        public void Publish<TMessage>(TMessage message)
        {
            var handlers = _container.ResolveAll<IMessageHandler<TMessage>>();
            foreach (var messageHandler in handlers)
            {
                messageHandler.Handle(message);

                _container.Release(messageHandler);
            }
        }
    }
}