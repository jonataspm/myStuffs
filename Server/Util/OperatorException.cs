using System.Runtime.Serialization;

namespace Server.Util
{
    [Serializable]
    internal class OperatorException : Exception
    {
        public OperatorException()
        {
        }

        public OperatorException(string? message) : base(message)
        {
        }

        public OperatorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected OperatorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}