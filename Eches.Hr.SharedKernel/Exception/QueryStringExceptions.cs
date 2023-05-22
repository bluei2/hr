using System.Globalization;

namespace Eches.Hr.SharedKernal.Exceptions
{
    public class UnsafeQueryStringException : Exception
    {
        public UnsafeQueryStringException() : base("The provided query string is not allowed as it is potentially unsafe")
        {
        }
        
        public UnsafeQueryStringException(string query, string unsafeMatches) : 
            base($"The provided query string is not allowed as it is potentially unsafe.\n\n{query}\n\nThe following unsafe matches were found:\n{unsafeMatches}")
        {
        }

    }


}
