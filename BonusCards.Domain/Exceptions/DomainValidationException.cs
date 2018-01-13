using System;

namespace BonusCards.Domain.Exceptions
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string message) : base (message)
        {
        }
    }
}
