using BookLibrary.Domain.Exceptions;
using BookLibrary.IntegrationTests.UserTests.Scenarios;
using BookLibrary.Model;
using FluentAssertions;
using Xunit;

namespace BookLibrary.IntegrationTests.UserTests
{
    [Collection("IntegrationTests")]
    public class UserRegisterPasswordTests:TestBase
    {
        [Fact]
        public void When_RegisterUserWithEmptyPassword_Should_ThrowException()
        {
            //Arrange
            var scenario = new RegisterUserScenario(Container)
            {
                GivingModel =  new UserModel()
                {
                    Name = "Lilei",
                    Password = string.Empty,
                    Email = "lilei@google.com",
                }
            };

            //Act
            scenario.Invoking(s => s.Execute()).ShouldThrow<DomainException>("invalid password");
        }

        [Fact]
        public void When_RegisterUserWithPassword_LessThanSixCharacters_Should_ThrowException()
        {
            //Arrange
            var scenario = new RegisterUserScenario(Container)
            {
                GivingModel = new UserModel()
                {
                    Name = "Lilei",
                    Password = "12345",
                    Email = "lilei@google.com",
                }
            };

            //Act
            scenario.Invoking(s => s.Execute()).ShouldThrow<DomainException>("password shorter than six characters");
        }

        [Fact]
        public void When_RegisterUserWithPassword_MissingUppercase_Should_ThrowException()
        {
            //Arrange
            var scenario = new RegisterUserScenario(Container)
            {
                GivingModel = new UserModel()
                {
                    Name = "Lilei",
                    Password = "password1",
                    Email = "lilei@google.com",
                }
            };

            //Act
            scenario.Invoking(s => s.Execute()).ShouldThrow<DomainException>("password missing uppercase characters");
        }

        [Fact]
        public void When_RegisterUserWithPassword_MissingLowercase_Should_ThrowException()
        {
            //Arrange
            var scenario = new RegisterUserScenario(Container)
            {
                GivingModel = new UserModel()
                {
                    Name = "Lilei",
                    Password = "PASSWORD1",
                    Email = "lilei@google.com",
                }
            };

            //Act
            scenario.Invoking(s => s.Execute()).ShouldThrow<DomainException>("password missing uppercase characters");
        }
    }
}