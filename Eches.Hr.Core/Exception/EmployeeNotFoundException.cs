using System.Globalization;

namespace Eches.Hr.Core.Exceptions
{
    public class EmployeeNotFoundException: Exception
    {
        public EmployeeNotFoundException(string message = "Employee not found") : base(message)
        {
        }
        public EmployeeNotFoundException(int EmployeeId) : base($"Employee with Id: [{ EmployeeId }] not found")
        {
        }
        
    }
}
