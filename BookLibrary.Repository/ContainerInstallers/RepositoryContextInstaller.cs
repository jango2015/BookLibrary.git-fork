using BookLibrary.Core;
using BookLibrary.Repository.EntityFramework;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BookLibrary.Repository.ContainerInstallers
{
    public class RepositoryContextInstaller : IWindsorInstaller
    {
        public const string EfRepositoryContextKey = "EFRepositoryContext";

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IRepositoryContext, IEntityFrameworkContext>()
                    .ImplementedBy<EntityFrameworkContext>()
                    .Named(EfRepositoryContextKey)
                    .LifestylePerWebRequest());
        }
    }
}