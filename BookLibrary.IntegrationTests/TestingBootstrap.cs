using BookLibrary.ApplicationService.ContainerInstallers;
using BookLibrary.ApplicationService.UowHelper;
using BookLibrary.Core.ContainerInstallers;
using BookLibrary.IntegrationTests.WindsorContainer;
using BookLibrary.QueryModelUpdater.ContainerInstallers;
using BookLibrary.Repository.ContainerInstallers;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace BookLibrary.IntegrationTests
{
    public class TestingBootstrap
    {
        private static IWindsorContainer _container;

        public static IWindsorContainer CreateContainer()
        {
            if (_container == null)
            {
                _container=new Castle.Windsor.WindsorContainer();
                UnitOfWorkRegistrar.Initialize(_container);

                _container.ChangeComponentsLifestyleToScoped();
                _container.Register(Component.For<IWindsorContainer>().Instance(_container));

                _container.Install(FromAssembly.This());
                _container.Install(FromAssembly.Containing<ApplicationServiceInstaller>());
                _container.Install(FromAssembly.Containing<RepositoryContextInstaller>());
                _container.Install(FromAssembly.Containing<UowInstaller>());
                _container.Install(FromAssembly.Containing<QueryModelUpdaterInstaller>());
            }

            return _container;
        }
    }
}