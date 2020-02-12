import DomBuilder from "../src/DomBuilder"

describe('XmlBuilder', () => {
  it('adds stuff above root', () => {
    new DomBuilderTest().testAddAboveRoot()
  })
})

class DomBuilderTest {
  testAddAboveRoot () {
    const builder = new DomBuilder('order')

    builder.addAbove('orders')

    expect(builder.generate()).toBe('<orders><order></order></orders>')
  }
}
