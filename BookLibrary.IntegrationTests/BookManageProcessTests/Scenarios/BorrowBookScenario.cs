using System;
using BookLibrary.ApplicationService.Contracts;
using BookLibrary.DomainModel;
using BookLibrary.IntegrationTests.BookTests.Scenarios;
using BookLibrary.IntegrationTests.UserTests.Scenarios;
using Castle.Windsor;

namespace BookLibrary.IntegrationTests.BookManageProcessTests.Scenarios
{
    public class BorrowBookScenario:ScenarioBase
    {
        public BorrowBookScenario(IWindsorContainer container) : base(container)
        {
            var registerUserScenario = new RegisterUserScenario(container);
            registerUserScenario.Execute();
            UserId = registerUserScenario.Id;
            GivingUserModel = registerUserScenario.GivingModel;

            var bookAddScenario=new BookAddScenario(container);
            bookAddScenario.Execute();
            BookId = bookAddScenario.Id;
            GivingBookModel = bookAddScenario.GivingModel;
        }

        public UserModel GivingUserModel { get; private set; }

        public BookModel GivingBookModel { get; private set; }

        public Guid BookId { get; private set; }

        public Guid UserId { get; private set; }

        public override void Execute()
        {
            var bookManageService = Container.Resolve<IBookBorrowedProcessService>();

            bookManageService.BorrowBook(UserId,BookId,TimeSpan.FromDays(1));
        }
    }
}