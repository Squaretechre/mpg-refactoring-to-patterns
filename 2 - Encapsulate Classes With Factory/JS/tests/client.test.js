import client from '../src/client'
import DefaultDescriptor from "../src/descriptors/DefaultDescriptor";

describe('client', () => {
  it('creates the correct attribute descriptors', () => {
    const expectedAttributeDescriptors = [
      new DefaultDescriptor("remoteId", 'number'),
      new DefaultDescriptor("createdDate", 'Date'),
      new DefaultDescriptor("lastChangedDate", 'Date'),
      new DefaultDescriptor("createdBy", 'string'),
      new DefaultDescriptor("lastChangedBy", 'string'),
      new DefaultDescriptor("optimisticLockVersion", 'number'),
    ]

    const actualAttributeDescriptors = client().getAttributeDescriptors()

    expect(actualAttributeDescriptors).toEqual(expectedAttributeDescriptors)
  })
})
