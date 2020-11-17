using System;

namespace igoodi.receiver360.common.infrastructure.Exceptions.Domain.Assets
{
  public class InvalidAssetException : Exception
  {
    public string BrokenRules { get; private set; }

    public InvalidAssetException(string brokenRules)
    {
      BrokenRules = brokenRules;
    }
  }
}