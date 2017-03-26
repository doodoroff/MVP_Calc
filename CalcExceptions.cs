using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Calc
{
    [Serializable]
    public class CalcException : Exception
    {
        public string ExceptionComment { get; set; }
        public CalcException() { }
        public CalcException(string message) : base(message) { }
        public CalcException(string message, Exception inner) : base(message, inner) { }
        protected CalcException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
