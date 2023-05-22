using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchesHr.Domain.ViewModel
{
    public class ResponseViewModel
    {
        public ResponseViewModel(int statusCode, bool succeeded, string message)
        {
            StatusCode = statusCode;
            Succeeded = succeeded;
            Message = message;
        }

        /// <summary>
        /// Success response
        /// </summary>
        /// <param name="message">Success message</param>
        public ResponseViewModel(string message)
        {
            Message = message;
            Succeeded = true;
            StatusCode = 200;
        }


        /// <summary>
        /// Failed resposne
        /// </summary>
        /// <param name="message">Failed response message</param>
        /// <param name="succeeded">Failed</param>
        public ResponseViewModel(string message, bool succeeded = false)
        {
            Message = message;
            Succeeded = false;
            StatusCode = 400;
        }

        public int StatusCode { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
