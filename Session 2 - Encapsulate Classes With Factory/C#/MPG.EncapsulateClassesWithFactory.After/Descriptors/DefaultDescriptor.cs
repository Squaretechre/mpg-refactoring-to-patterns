using System;

namespace MPG.EncapsulateClassesWithFactory.After.Descriptors
{
    public class DefaultDescriptor : AttributeDescriptor
    {
        public DefaultDescriptor(string name, Type classType, Type attributeType) : base(name, classType, attributeType)
        {
        }
    }
}
