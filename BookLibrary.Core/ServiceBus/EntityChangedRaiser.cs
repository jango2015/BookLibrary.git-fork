using BookLibrary.Core.Event;
using BookLibrary.Core.Uow;

namespace BookLibrary.Core.ServiceBus
{
    public class EntityChangedRaiser
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IServiceBus _serviceBus;

        public EntityChangedRaiser(IUnitOfWorkManager unitOfWorkManager, IServiceBus serviceBus)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _serviceBus = serviceBus;
        }

        public void RaiseEntityCreatedEvent<TEvent>(TEvent evt) where TEvent : IEntityCreatedEvent
        {
            RaiseEvent(evt);
        }

        public void RaiseEntityUpdatedEvent<TEvent>(TEvent evt) where TEvent:IEntityUpdatedEvent
        {
            RaiseEvent(evt);
        }

        public void RaiseEntityDeletedEvent<TEvent>(TEvent evt) where TEvent:IEntityDeletedEvent
        {
            RaiseEvent(evt);
        }

        private void RaiseEvent<TEvent>(TEvent evt)
        {
            _unitOfWorkManager.Current.RegisterCompleted(() => _serviceBus.Publish(evt));
        }
    }
}