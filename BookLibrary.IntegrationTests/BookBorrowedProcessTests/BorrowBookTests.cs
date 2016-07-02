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
            //var process = BookBorrowedProcessService.GetBookBorrowedProcess(borrowBookScenario.UserId);
            //process.BookBorrowedRecords.Count.Should().Be(1);
            //process.BookBorrowedRecords.First().Book.Number.Should().Be(borrowBookScenario.GivingBookModel.Number - 1);
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