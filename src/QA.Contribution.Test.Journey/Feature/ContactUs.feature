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

Scenario: The customer submits the contact form successfully
	Given the Contact Us page is displayed
	When the customer enters valid values in below fields:
		| name | email          | phone       | subject             | message                                |
		| Alex | alex@gmail.com | 07710022388 | Enquiry about hotel | Need your contact details to know more |
	And the customer submits the contact form
	Then the message is successfully submitted

@refactor
Scenario: The customer provides an invalid email address
	Given the Contact Us page is displayed
	When the customer enters valid values in below fields:
		| name | phone       | subject             | message                                |
		| Alex | 07710022388 | Enquiry about hotel | Need your contact details to know more |
	And the customer enters an empty string into the email address field
	And the customer submits the contact form
	Then the error message "Email may not be blank" is displayed

@failing
Scenario: The customer provides a malformed email address
	Given the Contact Us page is displayed
	When the customer enters valid values in below fields:
		| name | phone       | subject             | message                                |
		| Alex | 07710022388 | Enquiry about hotel | Need your contact details to know more |
	And the customer enters malformed email address
	And the customer submits the contact form
	Then the error message "must be a well-formed email address" is displayed


Scenario Outline: The customer provides an invalid phone number
	Given the Contact Us page is displayed
	When the customer enters valid values in below fields:
		| name | email          | subject             | message                                |
		| Alex | Alex@gmail.com | Enquiry about hotel | Need your contact details to know more |
	And the customer enters an invalid "<phone-number>" phone number
	And the customer submits the contact form
	Then the error message "<error-message>" is displayed

Examples:
	| phone-number           | error-message                                       |
	| 1234567890             | Phone must be between 11 and 21 characters.         |
	| 1234567890123456789011 | Phone must be between 11 and 21 characters.         |
