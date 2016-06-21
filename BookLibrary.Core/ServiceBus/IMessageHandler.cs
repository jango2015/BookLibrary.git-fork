namespace BookLibrary.Core.ServiceBus
{
    public interface IMessageHandler<in TMessage>
    {
        void Handle(TMessage message);
    }
}