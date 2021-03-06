﻿using System;
using System.Linq;
using BookLibrary.ApplicationService.Contracts;
using BookLibrary.DomainModel;
using Castle.Windsor;

namespace BookLibrary.IntegrationTests.BookLibraryProcessTests.Scenarios
{
    public class ReturnBookScenario:ScenarioBase
    {
        public ReturnBookScenario(IWindsorContainer container) : base(container)
        {
            var borrowBookScenario=new BorrowBookScenario(container);
            borrowBookScenario.Execute();

            UserId = borrowBookScenario.UserId;
            BookId = borrowBookScenario.BookIds.First();
            GivingUserModel = borrowBookScenario.GivingUserModel;
            GivingBookModel = borrowBookScenario.GivingBookModel;
        }

        public BookModel GivingBookModel { get; private set; }

        public UserModel GivingUserModel { get; private set; }

        public Guid BookId { get; private set; }

        public Guid UserId { get; private set; }

        public override void Execute()
        {
            var bookManageService = Container.Resolve<IBookLibraryProcessService>();

            bookManageService.ReturnBook(UserId,BookId);
        }
    }
}