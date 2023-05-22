namespace Eches.Hr.Core.Exceptions
{
    public class LeaveTypeNotFoundException: Exception
    {
        public LeaveTypeNotFoundException(string message = "Leave type not found.") : base(message) { }
    }
   
}
