﻿using System.Linq;
using BookLibrary.IntegrationTests.BookManageProcessTests.Scenarios;
using FluentAssertions;
using Xunit;

namespace BookLibrary.IntegrationTests.BookManageProcessTests
{
    [Collection("IntegrationTests")]
    public class ReturnBookTests:TestBase
    {
        [Fact]
        public void When_ReturnBook_Should_CreateReturnBookRecord()
        {
            //Arrange
            var returnBookScenario=new ReturnBookScenario(Container);

            //Act
            returnBookScenario.Execute();

            //Assert
            var process = BookManageProcessService.GetBookManageProcess(returnBookScenario.UserId);
            process.ReturnedBookRecords.Count.Should().Be(1);

            var returnRecord = process.ReturnedBookRecords.First();
            returnRecord.Book.Number.Should().Be(returnBookScenario.GivingBookModel.Number);
            returnRecord.IsPostpone.Should().Be(false);

        }
    }
}