using System.Globalization;

namespace Eches.Hr.Core.Exceptions
{
    public class ServerException : Exception
    {
        public ServerException() : base()
        {
        }
        public ServerException(string message) : base(message)
        {
        }
        public ServerException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
