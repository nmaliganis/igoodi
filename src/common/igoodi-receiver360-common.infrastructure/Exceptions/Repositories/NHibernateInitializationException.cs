using System;

namespace igoodi.receiver360.common.infrastructure.Exceptions.Repositories
{
    public class NHibernateInitializationException : Exception
    {
        public string Details { get; }
        public string InnerExceptionDetails { get; set; }

        public NHibernateInitializationException(string details)
        {
            Details = details;
        }

        public NHibernateInitializationException(string details, string innerExceptionDetails)
        {
            Details = details;
            InnerExceptionDetails = innerExceptionDetails;
        }

        public override string Message => "NHibernate initialization failed.\nDetails:" + Details + InnerExceptionDetails;
    }
}
