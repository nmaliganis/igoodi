using System;
using System.Collections.Generic;
using System.Reflection;

namespace igoodi.receiver360.common.infrastructure.Extensions
{
  public static class FilterExtensions
  {
    public static IEnumerable<TSource> FilterData<TSource>(
        this IEnumerable<TSource> source,
        string filterFields, string filter)
    {
      if (source == null)
      {
        throw new ArgumentNullException("source");
      }

      // create a list to hold our ExpandoObjects
      var expandoObjectList = new HashSet<TSource>();

      // create a list with PropertyInfo objects on TSource.  Reflection is
      // expensive, so rather than doing it for each object in the list, we do 
      // it once and reuse the results.  After all, part of the reflection is on the 
      // type of the object (TSource), not on the instance
      var propertyInfoList = new List<PropertyInfo>();

      if (string.IsNullOrWhiteSpace(filterFields))
      {
        // all public properties should be in the ExpandoObject
        var propertyInfos = typeof(TSource)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

        propertyInfoList.AddRange(propertyInfos);
      }
      else
      {
        // only the public properties that match the fields should be
        // in the ExpandoObject

        // the field are separated by ",", so we split it.
        var fieldsAfterSplit = filterFields.Split(',');

        foreach (var field in fieldsAfterSplit)
        {
          // trim each field, as it might contain leading 
          // or trailing spaces. Can't trim the var in foreach,
          // so use another var.
          var propertyName = field.Trim();

          // use reflection to get the property on the source object
          // we need to include public and instance, b/c specifying a binding flag overwrites the
          // already-existing binding flags.
          var propertyInfo = typeof(TSource)
              .GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

          if (propertyInfo == null)
          {
            throw new Exception($"Property {propertyName} wasn't found on {typeof(TSource)}");
          }

          // add propertyInfo to list 
          propertyInfoList.Add(propertyInfo);
        }
      }

      // run through the source objects
      foreach (TSource sourceObject in source)
      {
        // Get the value of each property we have to return.  For that,
        // we run through the list
        foreach (var propertyInfo in propertyInfoList)
        {
          // GetValue returns the value of the property on the source object
          var propertyValue = propertyInfo.GetValue(sourceObject);

          if (propertyValue.ToString().ToLowerInvariant().Contains(filter))
            expandoObjectList.Add(sourceObject);
        }

        // add the ExpandoObject to the list

      }

      // return the list

      return expandoObjectList;
    }
  }
}
