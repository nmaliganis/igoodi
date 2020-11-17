using System;

namespace igoodi.receiver360.common.infrastructure.Exceptions.Domain.Assets
{
    public class AssetDoesNotExistException : Exception
    {
        public Guid AssetId { get; }
        public string AssetName { get; }

        public AssetDoesNotExistException(Guid assetId)
        {
            AssetId = assetId;
        }

        public AssetDoesNotExistException(string assetName)
        {
          AssetName = assetName;
        }

        public override string Message => $"Asset with Id: {AssetId} or Name:{AssetName} doesn't exists!";
    }
}
