import XmlBuilder from "../src/XmlBuilder"

describe('XmlBuilder', () => {
  it('adds stuff above root', () => {
    new XmlBuilderTest().testAddAboveRoot()
  })
})

class XmlBuilderTest {
  testAddAboveRoot () {
    const builder = new XmlBuilder('order')

    builder.addAbove('orders')

    expect(builder.generate()).toBe('<orders><order></order></orders>')
  }
}
