namespace BookLibrary.Core.ServiceBus
{
    public interface IServiceBus
    {
        void Publish<TMessage>(TMessage message);
    }
}