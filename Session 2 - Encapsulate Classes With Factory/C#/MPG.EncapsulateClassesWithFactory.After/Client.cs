using System.Collections.Generic;
using MPG.EncapsulateClassesWithFactory.After.Descriptors;

namespace MPG.EncapsulateClassesWithFactory.After
{
    public class Client
    {
        public List<AttributeDescriptor> CreateAttributeDescriptors()
        {
            return new List<AttributeDescriptor>
            {
                AttributeDescriptor.ForInteger("remoteId", GetType()),
                AttributeDescriptor.ForDate("createdDate", GetType()),
                AttributeDescriptor.ForDate("lastChangedDate", GetType()),
                AttributeDescriptor.ForString("createdBy", GetType()),
                AttributeDescriptor.ForString("lastChangedBy", GetType()),
                AttributeDescriptor.ForInteger("optimisticLockVersion", GetType())
            };
        }
    }
}
