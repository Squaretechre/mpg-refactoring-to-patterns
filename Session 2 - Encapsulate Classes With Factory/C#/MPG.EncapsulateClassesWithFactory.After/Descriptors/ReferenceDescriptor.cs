using System;

namespace MPG.EncapsulateClassesWithFactory.After.Descriptors
{
    public class ReferenceDescriptor : AttributeDescriptor
    {
        public ReferenceDescriptor(string name, Type classType, Type attributeType) : base(name, classType, attributeType)
        {
        }
    }
}
