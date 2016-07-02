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
        protected IBookBorrowedProcessService BookBorrowedProcessService => Container.Resolve<IBookBorrowedProcessService>();

        protected IUserQueryReader UserQueryReader => Container.Resolve<IUserQueryReader>();
        protected IBookBorrowedProcessQueryReader BookBorrowedProcessQueryReader=> Container.Resolve<IBookBorrowedProcessQueryReader>();


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