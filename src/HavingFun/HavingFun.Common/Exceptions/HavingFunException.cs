using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Exceptions
{

    [Serializable]
    public class HavingFunException : Exception
    {
        public HavingFunException() { }
        public HavingFunException(string message) : base(message) { }
        public HavingFunException(string message, Exception inner) : base(message, inner) { }
        protected HavingFunException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
