using FluentNHibernate.Mapping;
using igoodi.receiver360.common.infrastructure.Domain;

namespace igoodi.receiver360.repository.Mappings.Base
{
    public abstract class VersionedClassMap<T> : ClassMap<T> where T : IVersionedEntity
    {
        protected VersionedClassMap()
        {
            Version(x => x.Revision)
                .Column("Revision")
                .CustomSqlType("integer")
                .Generated.Always()
                .UnsavedValue("null");
        }
    }
}