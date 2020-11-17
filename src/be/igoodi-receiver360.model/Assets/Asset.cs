using System;
using System.Collections.Generic;
using igoodi.receiver360.common.infrastructure.Domain;

namespace igoodi.receiver360.model.Assets
{
  public class Asset : EntityBase<Guid>, IAggregateRoot
  {
    public Asset()
    {
      OnCreate();
    }

    private void OnCreate()
    {
      this.IsActive = true;
      this.CreatedDate = DateTime.UtcNow;
      this.ModifiedDate = DateTime.UtcNow;
    }

    public virtual string Name { get; set; }
    public virtual Guid CreatedBy { get; set; }
    public virtual Guid ModifiedBy { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime ModifiedDate { get; set; }
    public virtual bool IsActive { get; set; }

    protected override void Validate()
    {
    }
    public virtual void InjectWithAudit(Guid accountIdToCreateThisAsset)
    {
      this.CreatedBy = accountIdToCreateThisAsset;
    }
  }
}


