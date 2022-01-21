import ContactUsPage from '../../../support/pages/ContactUsPage'
let contactUsPage = new ContactUsPage()

Given('the Contact Us page is displayed', () => {
  contactUsPage.openContactUs()
})

When('the customer enters a Basic Message intended for {string}', destination => {
  contactUsPage.selectSubjectHeading(destination)
  contactUsPage.enterEmail()
  contactUsPage.enterMessage()
})

When('the customer submits the message', () => {
  contactUsPage.clickSend()
})

When('the customer completes a Order Query message', () => {
	contactUsPage.selectSubjectHeading()
  contactUsPage.enterEmail()
  contactUsPage.enterMessage()
  contactUsPage.enterOrderReference()
})

When('the customer completes a Technical Support Request message', () => {
  contactUsPage.selectSubjectHeading()
  contactUsPage.enterEmail()
  contactUsPage.enterMessage()
})

When('the form is completed without the Subject Heading', () => {
  contactUsPage.enterEmail()
  contactUsPage.enterMessage()
  contactUsPage.enterOrderReference()
})

When('the form is completed without an email', () => {
	contactUsPage.selectSubjectHeading()
  contactUsPage.enterMessage()
  contactUsPage.enterOrderReference()
})

When('the form is completed with an invalid email', () => {
	contactUsPage.selectSubjectHeading()
  contactUsPage.enterInvalidEmail()
  contactUsPage.enterMessage()
  contactUsPage.enterOrderReference()
})

Then('the message is successfully submitted', () => {
  contactUsPage.messageSuccessfullySubmitted()
})

Then('the missing Subject Heading warning is shown', () => {
  contactUsPage.missingSubjectHeadingWarning()
})

Then('the invalid email warning is shown', () => {
  contactUsPage.invalidEmailWarning()
})

