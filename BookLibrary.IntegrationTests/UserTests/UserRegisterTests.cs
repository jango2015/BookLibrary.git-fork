using System;
using BookLibrary.Domain.Exceptions;
using BookLibrary.DomainModel;
using BookLibrary.IntegrationTests.UserTests.Scenarios;
using FluentAssertions;
using Xunit;

namespace BookLibrary.IntegrationTests.UserTests
{
    [Collection("IntegrationTests")]
    public class UserRegisterTests : TestBase
    {
        [Fact]
        public void When_RegisterUserWithEmptyName_Should_ThrowException()
        {
            //Arrange
            var scenario=new RegisterUserScenario(Container)
            {
                GivingModel = new UserModel()
                {
                    Name = string.Empty,
                    Email = "lilei@google.com",
                    Password = "Password1"
                }
            };

            //Act
            scenario.Invoking(s => s.Execute()).ShouldThrow<Exception>("invalid username");
        }


        [Fact]
        public void When_RegisterUserWithValidData_Should_CreateUser()
        {
            //Arrange
            var scenario=new RegisterUserScenario(Container);

            //Act
            scenario.Execute();

            //Assert
            var user = UserQueryReader.Get(scenario.Id);

            user.Name.Should().Be(scenario.GivingModel.Name);
            user.Email.Should().Be(scenario.GivingModel.Email);
        }

        [Fact]
        public void When_RegisterUserWithSameEmailTwice_Should_ThrowException()
        {
            //Arrange
            var scenario=new RegisterUserScenario(Container);

            //Act
            scenario.Execute();

            scenario.Invoking(s => s.Execute()).ShouldThrow<DuplicateEmailException>("email already exist");
        }
    }
}