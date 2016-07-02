using System;
using BookLibrary.ApplicationService.Contracts;
using BookLibrary.QueryModelReader.Contracts;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace BookLibrary.IntegrationTests
{
    public class TestBase : IDisposable
    {
        private readonly IDisposable _scope;

        protected IWindsorContainer Container { get; }

        protected IUserService UserService => Container.Resolve<IUserService>();
        protected IBookService BookService => Container.Resolve<IBookService>();
        protected IBookLibraryProcessService BookLibraryProcessService => Container.Resolve<IBookLibraryProcessService>();

        protected IUserQueryReader UserQueryReader => Container.Resolve<IUserQueryReader>();
        protected IBookLibraryProcessQueryReader BookLibraryProcessQueryReader=> Container.Resolve<IBookLibraryProcessQueryReader>();


        public TestBase()
        {
            Container = TestingBootstrap.CreateContainer();
            _scope = Container.BeginScope();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}