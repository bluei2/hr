using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eches.Hr.Core.Constant
{
    public static class ResponseMessage
    {
        public const string LoginFailed = "Email address or password provided is incorrect";
        public const string AccountLocked = "This account is locked";
        public const string Require2fa = "Please enter otp sent to your email address to continue";
        public const string ChangePasswordSucceeded = "Password changed successfully";
        public static string ChangePasswordFailed = "Password change failed";
        public static string RefreshTokenSucceeded = "Refresh token succeeded";
        public static string RefreshTokenFailed = "Refresh token failed. Session is not valid";
        public static string EmployeeAssignSuccess = "Employee successfully linked to the specified user";
        public static string EchesUserCreatedSubject = "EchesHr user has been created";
        public static object? EmployeeNotFound = "Employee not found.";
        public static string ForgotPasswordResponse= "If the information matches with our records. An email with instruction will be sent to the requested email address";
        public static string IdIsNull = "Id was null. An Id is required for this action";
        public static string UserCreationFailed = "User creation failed";
    }
}
