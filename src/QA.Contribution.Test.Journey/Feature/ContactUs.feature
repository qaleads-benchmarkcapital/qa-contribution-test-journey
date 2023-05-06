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

#refactoredByElsi
Scenario: The one where the customer provides an invalid email address
	Given the Contact Us page is displayed
	When the customer leaves an email address field as empty 
	And the user enters a message into the message body field
	And the customer submits the message
	Then the message is not submitted successfully
	And the customer is informed of the email validation error

#FailingScenario-FixedByElsi
Scenario: The one where the customer provides a malformed email address
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with a malformed email address
	Then the user is presented with the correct validation message

#AddedByElsi 
Scenario: The one where the customer provides name as empty
Given the Contact Us page is displayed
When the customer completes a Basic Message with empty name field
Then the message is not submitted successfully
And the customer is informed of the empty name validation message

