using System.Linq;
using BookLibrary.Domain.Exceptions;
using BookLibrary.IntegrationTests.BookBorrowedProcessTests.Scenarios;
using FluentAssertions;
using Xunit;

namespace BookLibrary.IntegrationTests.BookBorrowedProcessTests
{
    [Collection("IntegrationTests")]
    public class BorrowBookTests:TestBase
    {
        [Fact]
         public void When_BorrowBook_Should_CreateBookBorrowedProcess()
         {
            //Arrange
            var borrowBookScenario=new BorrowBookScenario(Container);

            //Act
            borrowBookScenario.Execute();

            //Assert
            var bookBorrowedProcees = BookBorrowedProcessQueryReader.GetByUserId(borrowBookScenario.UserId);
            var process = bookBorrowedProcees.Last();
            process.BookBorrowedRecords.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void When_BorrowSameBookTwice_Should_ThrowException()
        {
            //Arrange
            var borrowBookScenario = new BorrowBookScenario(Container);

            //Act
            borrowBookScenario.Execute();

            borrowBookScenario.Invoking(s => s.Execute()).ShouldThrow<BorrowSameBookTwiceException>("borrow same twice");
        }

    }
}