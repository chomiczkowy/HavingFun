using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Exceptions
{

    [Serializable]
    public class HavingFunBusinessValidationException : HavingFunException
    {
        public HavingFunBusinessValidationException() { }
        public HavingFunBusinessValidationException(string message) : base(message) { }
        public HavingFunBusinessValidationException(string message, Exception inner) : base(message, inner) { }
        protected HavingFunBusinessValidationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
