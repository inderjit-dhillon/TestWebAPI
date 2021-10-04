using System;
using System.Collections.Generic;
using System.Text;

namespace TestWebAPI.Domain.OutputModels
{
    public class ResponseModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Response { get; set; }
    }
}
