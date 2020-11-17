namespace igoodi.receiver360.common.infrastructure.Helpers.Serializers
{
    public interface IJsonSerializer
    {

        T DeserializeObject<T>(string json);
        string SerializeObject(object item);
    }
}
