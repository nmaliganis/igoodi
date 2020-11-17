using System;

namespace igoodi.receiver360.common.infrastructure.Exceptions.Repositories
{
    public class NHibernateSessionTransactionFailedException : Exception
    {
        public string Details { get; }

        public NHibernateSessionTransactionFailedException(string details)
        {
            Details = details;
        }

        public override string Message => "NHibernate Session Commit Transaction failed.\nDetails:" + Details;
    }
}