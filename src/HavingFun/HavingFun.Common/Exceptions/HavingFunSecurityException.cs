using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Exceptions
{

    [Serializable]
    public class HavingFunSecurityException : HavingFunException
    {
        public HavingFunSecurityException() { }
        public HavingFunSecurityException(string message) : base(message) { }
        public HavingFunSecurityException(string message, Exception inner) : base(message, inner) { }
        protected HavingFunSecurityException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
