using BookLibrary.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BookLibrary.Repository.ContainerInstallers
{
    public class EntityFrameworkRepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                    .BasedOn(typeof(IRepository<>))
                    .WithServiceAllInterfaces()
                    .LifestylePerWebRequest());

        }
    }
}