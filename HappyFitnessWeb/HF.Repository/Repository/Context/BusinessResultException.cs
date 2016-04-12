using System;

namespace HF.Repository.Repository.Context
{
    [Serializable]
    public class BusinessResultException : Exception
    {
        public BusinessResultException() { }
        public BusinessResultException(string message) : base(message) { }
        public BusinessResultException(string message, Exception inner) : base(message, inner) { }
        protected BusinessResultException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}