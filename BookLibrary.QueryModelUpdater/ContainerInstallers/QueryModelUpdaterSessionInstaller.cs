using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BookLibrary.QueryModelUpdater.ContainerInstallers
{
    public class QueryModelUpdaterSessionInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IQueryModelUpdaterSession>()
                    .ImplementedBy<QueryModelUpdaterSession>()
                    .LifestylePerWebRequest());
        }
    }
}