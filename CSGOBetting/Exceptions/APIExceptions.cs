using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGOBetting.Exceptions
{
    class APIExceptions
    {
        public class APIRateLimitException : Exception
        {
            public APIRateLimitException()
            {
            }

            public APIRateLimitException(string message) : base(message)
            { 
            }

            public APIRateLimitException(string message, Exception inner) : base(message, inner)
            {
            }
        }

        public class APIFailureToCommunicateException : Exception
        {
            public APIFailureToCommunicateException()
            {
            }

            public APIFailureToCommunicateException(string message) : base(message)
            {
            }

            public APIFailureToCommunicateException(string message, Exception inner) : base(message, inner)
            {
            }
        }
    }
}
