import fixtures from '../fixtures/checkVideoContainer.json'

export default function execute() {
        try {
            cy.getBody(fixtures.videoContainer);
            return true;
        } catch {
            return false;
        }
};