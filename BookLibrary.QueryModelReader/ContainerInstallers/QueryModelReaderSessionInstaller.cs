using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BookLibrary.QueryModelReader.ContainerInstallers
{
    public class QueryModelReaderSessionInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IQueryModelReaderSession>()
                    .ImplementedBy<QueryModelReaderSession>()
                    .LifestylePerWebRequest());
        }
    }
}