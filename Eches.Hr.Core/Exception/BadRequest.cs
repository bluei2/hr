using System.Globalization;

namespace Eches.Hr.Core.Exceptions
{
    public class BadRequest : Exception
    {
        public BadRequest() : base()
        {
        }
        public BadRequest(string message) : base(message)
        {
        }
        public BadRequest(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }


}
