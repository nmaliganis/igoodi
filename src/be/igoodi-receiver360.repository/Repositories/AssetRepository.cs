using System;
using System.Linq;
using igoodi.receiver360.common.infrastructure.Domain.Queries;
using igoodi.receiver360.common.infrastructure.Paging;
using igoodi.receiver360.model.Assets;
using igoodi.receiver360.repository.ContractRepositories;
using igoodi.receiver360.repository.Repositories.Base;
using NHibernate;
using NHibernate.Criterion;

namespace igoodi.receiver360.repository.Repositories
{
  public class AssetRepository : RepositoryBase<Asset, Guid>, IAssetRepository
  {
    public AssetRepository(ISession session)
      : base(session)
    {
    }

    public QueryResult<Asset> FindAllCategoriesPagedOf(int? pageNum = -1, int? pageSize = -1)
    {
      var query = Session.QueryOver<Asset>();

      if (pageNum == -1 & pageSize == -1)
      {
        return new QueryResult<Asset>(query?
          .Where(e => e.IsActive)
          .List()
          .AsQueryable());
      }

      return new QueryResult<Asset>(query
            .Where(e => e.IsActive)
            .Skip(ResultsPagingUtility.CalculateStartIndex((int)pageNum, (int)pageSize))
            .Take((int)pageSize).List().AsQueryable(),
          query.ToRowCountQuery().RowCount(),
          (int)pageSize)
        ;
    }

    public Asset FindByName(string name)
    {
      return (Asset)
        Session.CreateCriteria(typeof(Asset))
          .Add(Expression.Eq("Name", name))
          .UniqueResult()
        ;
    }
  }
}
