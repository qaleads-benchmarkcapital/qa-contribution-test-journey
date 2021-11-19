import fixtures from '../fixtures/navigateGoogle.json'

export default function execute() {
    cy.visit(fixtures.baseUrl);
    cy.getBody(fixtures.agreeButton).scrollIntoView().click();

    return cy.url().then((url) => {return url === fixtures.baseUrl});
};