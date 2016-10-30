using System;
using System.Runtime.Serialization;

namespace Repositories
{
    public class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException()
        {
        }

        public DuplicateTodoItemException(string message) : base(message)
        {
        }

        public DuplicateTodoItemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateTodoItemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}