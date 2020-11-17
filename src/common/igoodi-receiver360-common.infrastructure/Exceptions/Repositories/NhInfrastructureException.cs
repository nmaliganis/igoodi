using System;

namespace igoodi.receiver360.common.infrastructure.Exceptions.Repositories
{
    public class NhInfrastructureException : Exception
    {
        public string Details { get; private set; }

        public override string Message => "NHibernate Session Factory failed to be initialized.";

        public NhInfrastructureException(string strDetails)
        {
            Details = strDetails;
        }
    }
}
