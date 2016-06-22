using System;
using BookLibrary.Core.Event;
using BookLibrary.Core.Uow;
using Castle.Core.Internal;

namespace BookLibrary.Core.ServiceBus
{
    public class EntityChangedEventRaiser
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IServiceBus _serviceBus;

        public EntityChangedEventRaiser(IUnitOfWorkManager unitOfWorkManager, IServiceBus serviceBus)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _serviceBus = serviceBus;
        }

        public void RaiseEntityCreatedEvent<TEntity>(TEntity entity)
        {
            RaiseEvent(typeof(EntityCreatedEvent<>),entity);
        }

        public void RaiseEntityUpdatedEvent<TEntity>(TEntity entity)
        {
            RaiseEvent(typeof(EntityUpdatedEvent<>), entity);
        }

        public void RaiseEntityDeletedEvent<TEntity>(TEntity entity)
        {
            RaiseEvent(typeof(EntityDeletedEvent<>), entity);
        }

        private void RaiseEvent<TEntity>(Type genericEventType, TEntity entity)
        {
            var eventType = genericEventType.MakeGenericType(typeof (Entity));
            var evt = Activator.CreateInstance(eventType, new[] {entity});
            _unitOfWorkManager.Current.RegisterCompleted(() => _serviceBus.Publish(evt));
        }
    }
}