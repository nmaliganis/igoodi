using System;

namespace igoodi.receiver360.common.infrastructure.Exceptions.Common
{
    [Serializable]
    public class ChildObjectNotFoundException : Exception
    {
        public ChildObjectNotFoundException(string message) : base(message)
        {
        }
    }
}