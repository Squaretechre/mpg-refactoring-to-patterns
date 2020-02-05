using System;

namespace MPG.EncapsulateClassesWithFactory.Before.Descriptors
{
    public class DefaultDescriptor : AttributeDescriptor
    {
        public DefaultDescriptor(string name, Type classType, Type attributeType) : base(name, classType, attributeType)
        {
        }
    }
}
