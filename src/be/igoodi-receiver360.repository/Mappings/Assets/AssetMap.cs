using FluentNHibernate.Mapping;
using igoodi.receiver360.model.Assets;

namespace igoodi.receiver360.repository.Mappings.Assets
{
  public class AssetMap : ClassMap<Asset>
  {
    public AssetMap()
    {
      Table(@"categories");

      Id(x => x.Id)
        .Column("id")
        .CustomType("Guid")
        .Access.Property()
        .CustomSqlType("uuid")
        .Not.Nullable()
        .GeneratedBy
        .GuidComb()
        ;

      Map(x => x.Name)
        .Column("name")
        .CustomType("String")
        .Unique()
        .Access.Property()
        .Generated.Never()
        .CustomSqlType("varchar(128)")
        .Not.Nullable()
        .Length(256);

      Map(x => x.CreatedBy)
        .Column("created_by")
        .CustomType("Guid")
        .Access.Property()
        .Generated.Never()
        .CustomSqlType("UUID")
        .Nullable()
        ;

      Map(x => x.ModifiedBy)
        .Column("modified_by")
        .CustomType("Guid")
        .Access.Property()
        .Generated.Never()
        .CustomSqlType("UUID")
        .Nullable()
        ;

      Map(x => x.CreatedDate)
        .Column("created_date")
        .CustomType("DateTime")
        .Access.Property()
        .Generated.Never()
        .Not.Nullable()
        ;

      Map(x => x.ModifiedDate)
        .Column("modified_date")
        .CustomType("DateTime")
        .Access.Property()
        .Generated.Never()
        .Not.Nullable()
        ;

      Map(x => x.IsActive)
        .Column("active")
        .CustomType("Boolean")
        .Access.Property()
        .Generated.Never()
        .Default("true")
        .CustomSqlType("boolean")
        .Not.Nullable()
        ;
    }
  }
}
