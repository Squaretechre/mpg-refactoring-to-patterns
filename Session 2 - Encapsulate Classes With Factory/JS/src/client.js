// eslint-disable-next-line no-unused-vars
import DefaultDescriptor from "./descriptors/DefaultDescriptor"
import AttributeDescriptor from "./descriptors/AttributeDescriptor"

const client = () => {
  const getAttributeDescriptors = () => {
    return [
      (AttributeDescriptor.forNumber("remoteId")),
      (AttributeDescriptor.forDate("createdDate")),
      (AttributeDescriptor.forDate("lastChangedDate")),
      (AttributeDescriptor.forString("createdBy")),
      (AttributeDescriptor.forString("lastChangedBy")),
      (AttributeDescriptor.forNumber("optimisticLockVersion")),
    ]
  }

  return {
    getAttributeDescriptors
  }
}

export default client
