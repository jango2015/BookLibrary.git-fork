using BookLibrary.ApplicationService.Implements;
using BookLibrary.Domain.User;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BookLibrary.ApplicationService.ContainerInstallers
{
    public class UserComponetsInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IEmailUniqueChecker>().ImplementedBy<EmailUniqueChecker>().LifestylePerWebRequest());
        }
    }
}