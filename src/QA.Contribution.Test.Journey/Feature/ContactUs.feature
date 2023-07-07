Feature: ContactUs
	As a customer
	I want to contact customer services
	So that I can get support
	
	Description:
	A Contact Form that allows customers to send a message to customer servies.
	In submitting a message the customer uses the subject line to indicate the message title.
	In submitting a message the customer must provide a valid 'Email address' and a 'Messsage' body for the message to be submitted successfully.
	In submitting a message, the customer can provide a valid 'Phone' number.
	
	Glossary:
	Basic Message - A message that can be submitted.
	Invalid Email Address -  An empty string
	Malformed Email Address - An email address that does not validate as an email address, e.g. missing domain
	Invalid message - An empty string
	Invalid phone number - An empty string
	Invalid subject - An empty string
	Malformed phone number - A phone number that does not validate as a phone number, e.g <11 characters
	Malformed Subject - A subject that does not validate as a subject, eg. <5 characters
	Malformed message - A message that does not validate as a message, e.g <20 characters


Scenario: The one where the customer successfully submits a Basic Message
	Given the Contact Us page is displayed
	When the customer enters a Basic Message
	And the customer submits the message
	Then the message is successfully submitted

@refactor
Scenario: The one where the customer provides an invalid email address
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with an invalid email address
	And the customer submits the message
	Then the user is presented with the correct validation message

@failing
Scenario: The one where the customer provides a malformed email address
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with a malformed email address
	And the customer submits the message
	Then the user is presented with the correct validation message

Scenario: The one where the customer provides an invalid message
	Given the Contact Us page is displayed
	When the customer completes an invalid message
	And the customer submits the message
	Then the user is presented with the correct validation message

Scenario: The one where the customer provides an invalid phone number
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with an invalid phone number
	And the customer submits the message
	Then the user is presented with the correct validation message

Scenario: The one where the customer provides a malformed phone number
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with a malformed phone number
	And the customer submits the message
	Then the user is presented with the correct validation message

Scenario: The one where the customer provides a malformed message
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with a malformed message
	And the customer submits the message
	Then the user is presented with the correct validation message

Scenario: The one where the customer provides a malformed subject
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with a malformed subject
	And the customer submits the message
	Then the user is presented with the correct validation message