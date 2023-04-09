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

Scenario: The one where the customer successfully submits a Basic Message
	Given the Contact Us page is displayed
	When the customer enters a Basic Message
	And the customer submits the message
	Then the message is successfully submitted

@refactor
Scenario: The one where the customer provides an invalid email address
	Given the Contact Us page is displayed
	When the customer enters a Basic Message
	And the customer types an empty string into the email address field
	And the customer submits the message
	Then the customer is informed of the email validation error

@failing
Scenario: The one where the customer provides a malformed email address
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with a malformed email address
	And the customer submits the message
	Then the user is presented with the correct validation message

Scenario: The one where the customer leave name field empty
	Given the Contact Us page is displayed
	When the customer enter an empty string into the name field
	And the customer enters valid email address
	And the customer enters valid phone number
	And the customer enters valid subject
	And the user types a message into the message body field
	And the customer submits the message
	Then the customer is informed of the name validation error

@manual @ignore
Scenario: The one where the customer enter less then 5 characters in subject field
	Given the Contact Us page is displayed
	When the customer enters a Basic Message
	And the customer enters less then 5 characters in subject field
	And the customer submits the message
	Then the customer is informed of the subject validation error

@manual @ignore
Scenario: The one where the customer enter more then 21 characters in phone number field
	Given the Contact Us page is displayed
	When the customer enters a Basic Message
	And the customer enters more than 21 characters in phone number field
	And the customer submits the message
	Then the customer is informed of the phone number validation error

