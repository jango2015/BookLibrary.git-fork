using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BookLibrary.QueryModelReader.ContainerInstallers
{
    public class QueryReaderInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly().BasedOn<QueryReader>().WithServiceDefaultInterfaces().LifestylePerWebRequest());
        }
    }
}