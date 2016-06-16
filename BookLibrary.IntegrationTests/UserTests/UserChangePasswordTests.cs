using BookLibrary.IntegrationTests.UserTests.Scenarios;
using FluentAssertions;
using Xunit;

namespace BookLibrary.IntegrationTests.UserTests
{
    [Collection("IntegrationTests")]
    public class UserChangePasswordTests:TestBase
    {
        [Fact]
         public void When_ChangePasswordWithValidValue_Should_ChangeSuccessfull()
         {
            //Arrange
            var changePasswordScenario=new ChangePasswordScenario(Container);

            //Act
            changePasswordScenario.Execute();

            //Assert
             var login = UserService.Login(changePasswordScenario.Email, changePasswordScenario.NewPassword);
             login.Should().BeTrue();

         }
    }
}