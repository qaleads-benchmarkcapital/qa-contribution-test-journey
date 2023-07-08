Feature: ContactUs
	As a customer
	I want to contact customer services
	So that I can get support
	
	Description:
	A Contact Form that allows customers to send a message to customer servies.
	In submitting a message the customer uses the subject line to indicate the message title.
	In submitting a message the customer must provide a valid 'Email address' and a 'Messsage' body for the message to be submitted successfully.
	In submitting a message, the customer must provide a valid 'Phone' number.
	
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
	When the customer types an empty string into the email address field
	And the user types a message into the message body field
	And the customer submits the message
	Then the message is not submitted successfully
	And the customer is informed of the email validation error

@failing
Scenario: The one where the customer provides a malformed email address
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with a malformed email address
	Then the user is presented with the correct validation message

@task1
Scenario Outline: The one where the customer omits to enter an optional field
	Given the Contact Us page is displayed
	When the customer enters a Basic Message
	But omits the 'field name' field
	Then the message is not submitted successfully
	And the customer is informed of the 'field name' validation error

	Examples: 
	| response                 | field name    |
	| Email may not be blank   | Email Address |
	| Message may not be blank | Message       |
	| Subject may not be blank | Subject       |
	| Name may not be blank    | Name          |
	| Phone may not be blank   | Phone number  |

@task1
Scenario Outline: The one where the customer enters too few or too many characters
	Given the Contact Us page is displayed
	When the customer enters a Basic Message
	But the 'field name' is 'length' characters long
		Then the message is not submitted successfully
	And the customer is informed of the 'field name' validation error

	Examples: 
	| response                                       | field name   | length | reason    |
	| Message must be between 20 and 2000 characters | Message      | 19     | too short |
	| Message must be between 20 and 2000 characters | Message      | 2001   | too long  |
	| Subject must be between 5 and 100 characters   | Subject      | 4      | too short |
	| Subject must be between 5 and 100 characters   | Subject      | 101    | too long  |
	| Phone must be between 11 and 21 characters     | Phone number | 10     | too short |
	| Phone must be between 11 and 21 characters     | Phone number | 22     | too long  |