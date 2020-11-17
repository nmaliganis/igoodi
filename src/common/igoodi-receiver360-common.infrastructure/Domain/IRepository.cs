namespace igoodi.receiver360.common.infrastructure.Domain
{
    public interface IRepository<T, TId> : IReadOnlyRepository<T, TId>
        where T : IAggregateRoot
    {
        void Save(T entity);
        void Add(T entity);
        void Remove(T entity);
    }
}
