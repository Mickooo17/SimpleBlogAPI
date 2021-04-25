using System;

namespace SimpleBlog.Exceptions
{
    public class UserException : Exception
    {
        public UserException(string message)
            : base(message)
        {

        }
    }
}
