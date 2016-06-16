using BookLibrary.Core;

namespace BookLibrary.ApplicationService.Exceptions
{
    public class ApplicationServiceException: BookLibraryException
    {
        public ApplicationServiceException(string message):base(message)
        {
            
        }
    }
}