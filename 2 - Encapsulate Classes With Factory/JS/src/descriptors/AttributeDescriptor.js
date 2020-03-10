import DefaultDescriptor from "./DefaultDescriptor"

class AttributeDescriptor {
  constructor(name, attributeType) {
    this.name = name
    this.attributeType = attributeType
  }

  static forNumber(name) {
    return new DefaultDescriptor(name, 'number')
  }

  static forDate(name) {
    return new DefaultDescriptor(name, 'Date')
  }

  static forString(name) {
    return new DefaultDescriptor(name, 'string')
  }
}

export default AttributeDescriptor

