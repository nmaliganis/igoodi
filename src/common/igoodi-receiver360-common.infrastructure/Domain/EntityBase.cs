using System.Collections.Generic;
using System.Text;

namespace igoodi.receiver360.common.infrastructure.Domain
{
    public abstract class EntityBase<TId> : IEntity<TId>
    {
        private readonly IList<BusinessRule> _brokenRules;

        protected EntityBase()
        {
            _brokenRules = new List<BusinessRule>();
        }

        public virtual TId Id
        {
            get;
            set;
        }
        public virtual int Revision { get; set; }

        protected abstract void Validate();

        public virtual IEnumerable<BusinessRule> GetExtentBrokenRules()
        {
            return GetBrokenRules();
        }

        public virtual void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }

        public virtual IEnumerable<BusinessRule> GetBrokenRules()
        {
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }

        public virtual IEnumerable<BusinessRule> GetAllBrokenRules()
        {
            return _brokenRules;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public virtual string GetBrokenRulesAsString()
        {
            var sbBrokenRules = new StringBuilder();
            foreach (BusinessRule businessRule in GetBrokenRules())
            {
                sbBrokenRules.AppendLine($"Broken rule property: {businessRule.Property}");
                sbBrokenRules.AppendLine($"Broken rule rule: {businessRule.Rule}\n");
            }

            return sbBrokenRules.ToString();
        }

        public override bool Equals(object entity)
        {
            return entity != null
                && entity is EntityBase<TId>
                && this == (EntityBase<TId>)entity;
        }

        public static bool operator ==(EntityBase<TId> entity1, EntityBase<TId> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }

            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }

            if (entity1.Id.ToString() == entity2.Id.ToString())
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(EntityBase<TId> entity1, EntityBase<TId> entity2)
        {
            return !(entity1 == entity2);
        }
    }
}
