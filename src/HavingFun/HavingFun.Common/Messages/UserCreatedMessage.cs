using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Messages
{
    public class UserCreatedMessage
    {
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
