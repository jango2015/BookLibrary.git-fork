using BookLibrary.Core.ServiceBus;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using ServiceStack.Messaging;
using Component = System.ComponentModel.Component;

namespace BookLibrary.QueryModelUpdater.ContainerInstallers
{
    public class QueryModelUpdaterInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn(typeof(IMessageHandler<>)).WithServiceBase().LifestylePerWebRequest());
        }
    }
}