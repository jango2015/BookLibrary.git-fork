using BookLibrary.Core;

namespace BookLibrary.DomainService
{
    public class DomainService:IDomainService
    {
        public IRepositoryContext Context { get; private set; }

        public DomainService(IRepositoryContext context)
        {
            this.Context = context;
        }
    }
}