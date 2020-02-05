using System;
using System.Collections.Generic;
using MPG.EncapsulateClassesWithFactory.Before.Descriptors;

namespace MPG.EncapsulateClassesWithFactory.Before
{
    public class Client
    {
        public List<AttributeDescriptor> CreateAttributeDescriptors()
        {
            return new List<AttributeDescriptor>
            {
                new DefaultDescriptor("remoteId", GetType(), typeof(int)),
                new DefaultDescriptor("createdDate", GetType(), typeof(DateTime)),
                new DefaultDescriptor("lastChangedDate", GetType(), typeof(DateTime)),
                new DefaultDescriptor("createdBy", GetType(), typeof(string)),
                new DefaultDescriptor("lastChangedBy", GetType(), typeof(string)),
                new DefaultDescriptor("optimisticLockVersion", GetType(), typeof(int))
            };
        }
    }
}
