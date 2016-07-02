using System;
using System.Collections.Generic;
using BookLibrary.ApplicationService.Contracts;
using BookLibrary.DomainModel;
using BookLibrary.IntegrationTests.BookTests.Scenarios;
using BookLibrary.IntegrationTests.UserTests.Scenarios;
using Castle.Windsor;

namespace BookLibrary.IntegrationTests.BookBorrowedProcessTests.Scenarios
{
    public class BorrowBookScenario:ScenarioBase
    {
        public BorrowBookScenario(IWindsorContainer container) : base(container)
        {
            BookIds=new List<Guid>();

            var registerUserScenario = new RegisterUserScenario(container);
            registerUserScenario.Execute();
            UserId = registerUserScenario.Id;
            GivingUserModel = registerUserScenario.GivingModel;

            var bookAddScenario=new BookAddScenario(container);
            bookAddScenario.Execute();
            BookIds.Add(bookAddScenario.Id);
            GivingBookModel = bookAddScenario.GivingModel;
        }

        public UserModel GivingUserModel { get; private set; }

        public BookModel GivingBookModel { get; private set; }

        public List<Guid> BookIds { get; private set; }

        public Guid UserId { get; private set; }

        public override void Execute()
        {
            var bookManageService = Container.Resolve<IBookBorrowedProcessService>();

            bookManageService.BorrowBooks(UserId, BookIds, TimeSpan.FromDays(1));
        }
    }
}