using System;

namespace MPG.EncapsulateClassesWithFactory.Before.Descriptors
{
    public class ReferenceDescriptor : AttributeDescriptor
    {
        public ReferenceDescriptor(string name, Type classType, Type attributeType) : base(name, classType, attributeType)
        {
        }
    }
}
