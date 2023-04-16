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

Scenario: The customer provides an invalid name
	Given the Contact Us page is displayed
	When the customer enters valid values in below fields:
		| email          | phone       | subject             | message                                |
		| Alex@gmail.com | 07710022388 | Enquiry about hotel | Need your contact details to know more |
	And the customer enters an empty string into the name field
	And the customer submits the contact form
	Then the error message "Name may not be blank" is displayed

Scenario Outline: The customer provides phone number with less than 11 characters or more than 21 characters
	Given the Contact Us page is displayed
	When the customer enters valid values in below fields:
		| name | email          | subject             | message                                |
		| Alex | Alex@gmail.com | Enquiry about hotel | Need your contact details to know more |
	And the customer enters an invalid "<phone-number>" phone number
	And the customer submits the contact form
	Then the error message "<error-message>" is displayed

Examples:
	| phone-number           | error-message                               |
	| 1234567890             | Phone must be between 11 and 21 characters. |
	| 1234567890123456789011 | Phone must be between 11 and 21 characters. |

Scenario Outline: The customer provides subject with less than 5 characters or more than 100 characters
	Given the Contact Us page is displayed
	When the customer enters valid values in below fields:
		| name | email          | phone       | message                                |
		| Alex | Alex@gmail.com | 07710022388 | Need your contact details to know more |
	And the customer enters a subject with <subject-length> letters
	And the customer submits the contact form
	Then the error message "Subject must be between 5 and 100 characters." is displayed

Examples:
	| subject-length |
	| 4              |
	| 101            |

Scenario Outline: The customer provides message with less than 20 characters or more than 2000 characters
	Given the Contact Us page is displayed
	When the customer enters valid values in below fields:
		| name | email          | phone       | subject             |
		| Alex | alex@gmail.com | 07710022388 | Enquiry about hotel |
	And the customer enters a message with <message-length> letters
	And the customer submits the contact form
	Then the error message "Message must be between 20 and 2000 characters." is displayed

Examples:
	| message-length |
	| 19             |
	| 2001           |