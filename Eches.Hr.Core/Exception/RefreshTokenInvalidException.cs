namespace Eches.Hr.Core.Exceptions
{
    public class RefreshTokenInvalidException : Exception
    {
        public RefreshTokenInvalidException(string message = "Refresh token is invalid.") : base(message)
        {
        }
    }
}
