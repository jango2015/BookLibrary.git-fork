using Castle.Windsor;

namespace BookLibrary.Core
{
    public class IocContainerManager
    {
        public static IWindsorContainer Container { get; }

        static IocContainerManager()
        {
            Container=new WindsorContainer();
        }
    }
}