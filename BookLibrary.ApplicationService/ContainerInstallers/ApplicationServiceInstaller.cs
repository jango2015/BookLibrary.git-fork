using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BookLibrary.ApplicationService.ContainerInstallers
{
    public class ApplicationServiceInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                .BasedOn<IApplicationService>()
                .WithServiceDefaultInterfaces()
                .LifestylePerWebRequest()
                );
        }
    }
}