using System;

namespace igoodi.receiver360.common.infrastructure.Exceptions.Domain.Assets
{
    public class AssetDoesNotExistAfterMadePersistentException : Exception
    {
        public Guid AssetId { get; private set; }
        public string Name { get; private set; }

        public AssetDoesNotExistAfterMadePersistentException(string name)
        {
            Name = name;
        }
        public AssetDoesNotExistAfterMadePersistentException(Guid assetId)
        {
            AssetId = assetId;
        }

        public override string Message => $" Asset with Name: {Name} or Id: {AssetId} was not made Persistent!";
    }
}