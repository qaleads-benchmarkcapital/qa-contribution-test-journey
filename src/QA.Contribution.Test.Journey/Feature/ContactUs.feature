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

Scenario: The one where the customer provides blank Phone Number
	Given the Contact Us page is displayed
	When the customer enters a Basic Message
	When the customer types an empty integer into the phone field
    And  the customer submits the message 
	Then the message is not submitted successfully 

@manual  @ignore
Scenario: The one where the phone number is more than 21 character lenght.
	Given the Contact Us page is displayed
	When the customer enters a Basic Message
	When the customer enters phone number above 21 character lenght 
    And the customer submits the message 
	Then message display Phone must be between 11 and 21 character
	


@refactor
Scenario: The one where the customer provides an invalid email address
	Given the Contact Us page is displayed
	When the customer types an empty string into the email address field
	And the customer submits the message
	Then the customer is informed of the email validation error

@failing
Scenario: The one where the customer provides a malformed email address
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with a malformed email address
	Then the user is presented with the correct validation message