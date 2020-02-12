export default class DomBuilder {
  constructor (root) {
    this.structure = {}
    this.structure[root] = {}
  }

  addAbove (element) {
    const newStructure = {}
    newStructure[element] = this.structure
    this.structure = newStructure
  }

  generate () {
    const elements = Object.keys(this.structure).map(e => {
      const subElements = Object.keys(this.structure[e]).map(subE => `<${subE}></${subE}>`)
      return `<${e}>${subElements.join('')}</${e}>`
    })

    return elements.join('')
  }
}
