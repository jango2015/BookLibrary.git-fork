using BookLibrary.Core.ServiceBus;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BookLibrary.Core.ContainerInstallers
{
    public class EntityChangedEventRaiserInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<EntityChangedEventRaiser>().LifestylePerWebRequest());
        }
    }
}