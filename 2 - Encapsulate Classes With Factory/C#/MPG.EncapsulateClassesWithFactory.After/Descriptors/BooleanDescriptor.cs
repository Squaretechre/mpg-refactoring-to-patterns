using System;

namespace MPG.EncapsulateClassesWithFactory.After.Descriptors
{
    public class BooleanDescriptor : AttributeDescriptor
    {
        public BooleanDescriptor(string name, Type classType, Type attributeType) : base(name, classType, attributeType)
        {
        }
    }
}
