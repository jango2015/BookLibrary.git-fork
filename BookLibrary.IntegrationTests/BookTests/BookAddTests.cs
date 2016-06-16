using System;
using BookLibrary.IntegrationTests.BookTests.Scenarios;
using FluentAssertions;
using Xunit;

namespace BookLibrary.IntegrationTests.BookTests
{
    [Collection("IntegrationTests")]
    public class BookAddTests:TestBase
    {
        [Fact]
         public void After_AddedBook_Should_GetBookId()
         {
             //Arrange
             var bookAddScenario=new BookAddScenario(Container);
            
            //Act
            bookAddScenario.Execute();
            
            //Assert
            bookAddScenario.Id.Should().NotBe(Guid.Empty);
         }
    }
}