using System;

namespace MPG.EncapsulateClassesWithFactory.Before.Descriptors
{
    public class BooleanDescriptor : AttributeDescriptor
    {
        public BooleanDescriptor(string name, Type classType, Type attributeType) : base(name, classType, attributeType)
        {
        }
    }
}
