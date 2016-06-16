using System;
using BookLibrary.ApplicationService.Contracts;
using BookLibrary.Model;
using Castle.Windsor;

namespace BookLibrary.IntegrationTests.BookTests.Scenarios
{
    public class BookAddScenario:ScenarioBase
    {
        public Guid Id { get; set; }

        public BookModel GivingModel { get; set; }

        public BookAddScenario(IWindsorContainer container) : base(container)
        {
            GivingModel=new BookModel()
            {
                Name = "book1",
                Author = "David",
                ISBN = "111-222-333",
                Number = 10,
                Price = 10m,
                PublishDate = DateTime.Now
            };
        }

        public override void Execute()
        {
            var bookService = Container.Resolve<IBookService>();
            Id = bookService.AddNewBook(GivingModel);
        }

    }
}