using System.Collections.Generic;

namespace igoodi.receiver360.common.infrastructure.Domain
{
    public interface IReadOnlyRepository<T, in TId>
        where T : IAggregateRoot
    {
        T FindBy(TId id);
        IList<T> FindAll();
        IList<T> FindAll(int index, int count);
    }
}
