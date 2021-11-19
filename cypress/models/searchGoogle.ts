import fixtures from '../fixtures/searchGoogle.json'

export default function execute(text: string) {
    cy.getBody(fixtures.searchField).clear().type(text)
    cy.xpath(fixtures.searchButton).click()
};