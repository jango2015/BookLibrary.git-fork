using BookLibrary.Core.Uow;
using BookLibrary.Core.Uow.EntityFramework;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BookLibrary.Core.ContainerInstallers
{
    public class UowInstaller:IWindsorInstaller
    {
        public class UnitOfWorkKeys
        {
            public const string EfKey = "UnitOfWork.EntityFramework";
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ICurrentUnitOfWorkProvider>()
                    .ImplementedBy<CurrentUnitOfWorkProvider>()
                    .LifestylePerWebRequest());

            container.Register(Component.For<DefaultUnitOfWorkOptions>().LifestylePerWebRequest());

            container.Register(Component.For<IUnitOfWork>().ImplementedBy<EfUnitOfWork>().Named(UnitOfWorkKeys.EfKey).LifestylePerWebRequest());

            container.Register(Component.For<IUnitOfWorkManager>().ImplementedBy<UnitOfWorkManager>().LifestylePerWebRequest());

        }

       
    }
}