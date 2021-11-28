var emailLocator = 'input[id="email"]';
var orderReferenceLocator = 'input[id="id_order"]';
var messageLocator = 'textarea[id="message"]';
var submitMessageLocator = 'button[id="submitMessage"]';
var pageURL = 'http://automationpractice.com/index.php?controller=contact';
var email = 'email@email.com'
var invalidEmail = 'emailemail.com'

class ContactUsPage {
  constructor () {}

  	openContactUs () {
    	cy.visit(pageURL)
    	cy.url().should('eq', pageURL)
  	}

  	selectSubjectHeading (destination) {
  		const subjects = ["Customer service", "Webmaster"];
  		if (destination == null) {
  			destination = subjects[Math.floor(Math.random())];
  		}
  		cy.get('select').select(destination)
  	}

  	enterEmail () {
  		cy.get(emailLocator).type(email)
  	}

  	enterMessage () {
  		cy.get(messageLocator).type("This is a test message.")	
  	}

  	clickSend () {
  		cy.get(submitMessageLocator).click()
  	}

  	messageSuccessfullySubmitted () {
  		cy.contains("Your message has been successfully sent to our team.").should('be.visible')
  	}

  	enterOrderReference () {
  		cy.get(orderReferenceLocator).type("xgfdt65t")
  	}

  	missingSubjectHeadingWarning () {
  		cy.contains("Please select a subject from the list provided").should('be.visible')
  	}

  	invalidEmailWarning () {
  		cy.contains("Invalid email address").should('be.visible')
  	}

  	enterInvalidEmail() {
  		cy.get(emailLocator).type(invalidEmail)
  	}

}

export default ContactUsPage