using System.Data.Common;
using System.Data.Entity;
using BookLibrary.Repository.EntityFramework;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Effort;

namespace BookLibrary.IntegrationTests.WindsorInstallers
{
    public class FakeDbContextInstaller:IWindsorInstaller
    {
        public const string DbConnectionKey = "FakeDbConnection";
        public const string FakeBookLibraryDbContextKey = "FakeBookLibraryDbContext";
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(
                Component.For<DbConnection>().UsingFactoryMethod(DbConnectionFactory.CreateTransient)
                    .Named(DbConnectionKey)
                    .LifestylePerWebRequest()
                    );

            container.Register(Component.For<DbContext>()
                .ImplementedBy<BookLibraryDbContext>()
                .DependsOn(Dependency.OnComponent(typeof(DbConnection), DbConnectionKey))
                .Named(FakeBookLibraryDbContextKey)
                .LifestylePerWebRequest()
                .IsDefault());

        }
    }
}