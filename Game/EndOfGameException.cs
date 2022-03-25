using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class EndOfGameException : Exception
    {
        public EndOfGameException() : base() { }
        public EndOfGameException(string message) : base(message) { }
        public EndOfGameException(string message, Exception inner) : base(message, inner) { }
        protected EndOfGameException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }
}
