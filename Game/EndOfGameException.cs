using System;

namespace Game
{
    public class EndOfGameException : Exception
    {
        public EndOfGameException() : base() { }
        public EndOfGameException(string message) : base(message) { }
        public EndOfGameException(string message, Exception inner) : base(message, inner) { }
        protected EndOfGameException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }
}
