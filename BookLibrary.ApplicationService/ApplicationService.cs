using BookLibrary.Core;

namespace BookLibrary.ApplicationService
{
    public class ApplicationService
    {
        public IRepositoryContext Context { get; private set; }

        public ApplicationService(IRepositoryContext context)
        {
            this.Context = context;
        }
    }
}