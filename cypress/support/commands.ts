// Must be declared global to be detected by typescript (allows import/export)
// eslint-disable @typescript/interface-name
declare global {
    // eslint-disable-next-line @typescript-eslint/no-namespace
    namespace Cypress {
      interface Chainable<Subject> {
        
        /**
         * Get element by xpath from body.
         * Appends any xpath with "//body".
         * @example cy.getBody('//*[text()="Hello World"]')
         */
        getBody(xpath: string): Chainable<Element>;
        
      }
    }
  }

  Cypress.Commands.add('getBody', (xpath) => { return cy.xpath(`//body${xpath}`) })

export {}