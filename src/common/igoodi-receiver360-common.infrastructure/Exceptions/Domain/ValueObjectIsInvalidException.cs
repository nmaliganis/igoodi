using System;

namespace igoodi.receiver360.common.infrastructure.Exceptions.Domain
{
    public class ValueObjectIsInvalidException : Exception
    {
        public ValueObjectIsInvalidException(string message)
            : base(message)
        {

        }
    }
}