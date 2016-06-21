using BookLibrary.Core.ServiceBus;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BookLibrary.Core.ContainerInstallers
{
    public class ServiceBusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IServiceBus>().ImplementedBy<SyncServiceBus>().LifestylePerWebRequest());
        }
    }
}