using System;
using BookLibrary.ApplicationService.Contracts;
using BookLibrary.DomainModel;
using Castle.Windsor;

namespace BookLibrary.IntegrationTests.UserTests.Scenarios
{
    public class RegisterUserScenario : ScenarioBase
    {
        public UserModel GivingModel { get; set; }

        public Guid Id { get; private set; }

        public RegisterUserScenario(IWindsorContainer container):base(container)
        {
            GivingModel = new UserModel()
            {
                Name = "Lilei",
                Password = "Password1",
                Email = "lilei@google.com",
            };
        }

        public override void Execute()
        {
            var userService = Container.Resolve<IUserService>();
            Id = userService.Register(GivingModel);
        }
    }
}