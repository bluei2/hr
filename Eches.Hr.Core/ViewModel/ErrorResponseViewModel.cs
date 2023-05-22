using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eches.Hr.Core.ViewModel.Response
{
    public class ErrorResponseViewModel
    {
        public string TraceId { get; set; }
        public bool Succeeded { get; set; } = false;
        public string Message { get; set; } = "An error occured while processing your request";
        public int Code { get; set; } = 400;
        public dynamic? Payload { get; set; }
    }
}
