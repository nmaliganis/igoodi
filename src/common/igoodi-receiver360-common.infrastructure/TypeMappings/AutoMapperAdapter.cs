using AutoMapper;

namespace igoodi.receiver360.common.infrastructure.TypeMappings
{
    public class AutoMapperAdapter : IAutoMapper
    {
        public T Map<T>(object objectToMap)
        {
            return Mapper.Map<T>(objectToMap);
        }

        public TDest Map<TSource, TDest>(TSource objectSource, TDest objectDest)
        {
            return Mapper.Map(objectSource, objectDest);
        }
    }
}