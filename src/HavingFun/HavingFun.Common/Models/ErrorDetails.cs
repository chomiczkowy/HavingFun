using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Models
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Guid? Id { get; set; }
    }
}
