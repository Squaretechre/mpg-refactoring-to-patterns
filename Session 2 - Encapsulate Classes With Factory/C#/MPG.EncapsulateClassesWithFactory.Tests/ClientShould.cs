using System;
using System.Collections.Generic;
using System.Linq;
using MPG.EncapsulateClassesWithFactory.Before;
using MPG.EncapsulateClassesWithFactory.Before.Descriptors;
using Xunit;

namespace MPG.EncapsulateClassesWithFactory.Tests
{
    public class ClientShould
    {
        [Fact]
        public void create_correct_attribute_descriptors()
        {
            var expectedAttributeDescriptors = new List<AttributeDescriptor>
            {
                new DefaultDescriptor("remoteId", typeof(Client), typeof(int)),
                new DefaultDescriptor("createdDate", typeof(Client), typeof(DateTime)),
                new DefaultDescriptor("lastChangedDate", typeof(Client), typeof(DateTime)),
                new DefaultDescriptor("createdBy", typeof(Client), typeof(string)),
                new DefaultDescriptor("lastChangedBy", typeof(Client), typeof(string)),
                new DefaultDescriptor("optimisticLockVersion", typeof(Client), typeof(int))
            };

            var actualAttributeDescriptors = new Client().CreateAttributeDescriptors();

            Assert.True(expectedAttributeDescriptors.SequenceEqual(actualAttributeDescriptors));
        }
    }
}
