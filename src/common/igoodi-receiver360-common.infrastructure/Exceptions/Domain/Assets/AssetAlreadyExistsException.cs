using System;

namespace igoodi.receiver360.common.infrastructure.Exceptions.Domain.Assets
{
    public class AssetAlreadyExistsException : Exception
    {
        public string Name { get; }
        public string BrokenRules { get; }

        public AssetAlreadyExistsException(string name)
           : this(name, "NO_BROKEN_RULES")
        {
        }
        public AssetAlreadyExistsException(string name, string brokenRules)
        {
            Name = name;
            BrokenRules = brokenRules;
        }

        public override string Message => $" Asset with name:{Name} already Exists!\n Additional info:{BrokenRules}";
    }
}
