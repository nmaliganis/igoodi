using System;
using igoodi.receiver360.common.infrastructure.Domain;
using igoodi.receiver360.common.infrastructure.Domain.Queries;
using igoodi.receiver360.model.Assets;

namespace igoodi.receiver360.repository.ContractRepositories
{
  public interface IAssetRepository : IRepository<Asset, Guid>
  {
    QueryResult<Asset> FindAllCategoriesPagedOf(int? pageNum, int? pageSize);
    Asset FindByName(string name);
  }
}
