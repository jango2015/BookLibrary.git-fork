using System;
using BookLibrary.Core.Uow;
using Castle.Core.Internal;

namespace BookLibrary.Core.ServiceBus
{
    public class EventRaiser
    {
        public static void RaiseEvent<TEvent>(TEvent evt)
        {
            var unitOfWorkManager = IocContainerManager.Container.Resolve<IUnitOfWorkManager>();
            var serviceBus = IocContainerManager.Container.Resolve<IServiceBus>();

            unitOfWorkManager.Current.RegisterCompleted(() => serviceBus.Publish(evt));
        }
    }
}