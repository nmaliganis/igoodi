namespace igoodi.receiver360.common.infrastructure.Domain
{
    public interface IVersionedEntity
    {
        int Revision { get; set; }
    }
}