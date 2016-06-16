using System.Collections.Generic;

namespace BookLibrary.Domain.Exceptions
{
    public class PasswordDoesNotMatchPolicyException: DomainException
    {
        public IEnumerable<string> Failures { get; private set; }

        public PasswordDoesNotMatchPolicyException(IEnumerable<string> failures):base(string.Empty)
        {
            Failures = failures;
        }
    }
}