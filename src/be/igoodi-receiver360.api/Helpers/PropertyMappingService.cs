using System;
using System.Collections.Generic;
using igoodi.receiver360.common.dtos.Vms.Assets;
using igoodi.receiver360.common.infrastructure.PropertyMappings;
using igoodi.receiver360.model.Assets;

namespace igoodi.receiver360.api.Helpers
{
    public class PropertyMappingService : BasePropertyMapping
    {
        private readonly Dictionary<string, PropertyMappingValue> _assetPropertyMapping =
          new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
          {
            {"id", new PropertyMappingValue(new List<string>() {"id"})},
            {"Name", new PropertyMappingValue(new List<string>() {"Name"})},
            {"IsActive", new PropertyMappingValue(new List<string>() {"IsActive"})},
          };

        private static readonly IList<IPropertyMapping> PropertyMappings = new List<IPropertyMapping>();

        public PropertyMappingService() : base(PropertyMappings)
        {
            PropertyMappings.Add(new PropertyMapping<AssetUiModel, Asset>(_assetPropertyMapping));
        }
    }
}
