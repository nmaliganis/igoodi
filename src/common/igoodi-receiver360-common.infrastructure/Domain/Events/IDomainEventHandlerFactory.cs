using System.Collections.Generic;

namespace igoodi.receiver360.common.infrastructure.Domain.Events
{
    public interface IDomainEventHandlerFactory
    {
        IEnumerable<IDomainEventHandler<T>> GetDomainEventHandlersFor<T>(T domainEvent)
            where T : IDomainEvent;
    }
}