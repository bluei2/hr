using System.Globalization;

namespace Eches.Hr.Core.Exceptions
{
    public class Unauthorized : Exception //401
    {
        public Unauthorized() : base()
        {
        }
        public Unauthorized(string message) : base(message)
        {
        }
        public Unauthorized(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }

    public class Forbidden : Exception
    {
        public Forbidden() : base()
        {
        }
        public Forbidden(string message) : base(message)
        {
        }
        public Forbidden(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
            Data.Add("error", args);
        }
    }

    public class PolicyViolationException : Exception
    {
        public PolicyViolationException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {

            Data.Add("Policy", args);
        }
    }
}
