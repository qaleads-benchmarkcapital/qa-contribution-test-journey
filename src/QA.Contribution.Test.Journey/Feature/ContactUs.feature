﻿Feature: ContactUs
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
@ignore
Scenario: The one where the customer provides an invalid email address
	Given the Contact Us page is displayed
	When the customer types an empty string into the email address field
	And the user types a message into the message body field
	And the customer submits the message
	Then the message is not submitted successfully
	And the customer is informed of the email validation error

@failing
@task3
Scenario: The one where the customer provides a malformed email address
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with a malformed email address
	And the customer submits the message
	Then the message is not submitted successfully
	And the customer is informed of the 'must be a well-formed email address' validation error

@task1
@task2
Scenario Outline: The one where the customer omits to enter an optional field
	Given the Contact Us page is displayed
	When the customer enters a Basic Message
	But omits the 'field name' field
	Then the message is not submitted successfully
	And the customer is informed of the 'expected' validation error

	Examples: 
	| field name    | expected                 |
	| Email Address | Email may not be blank   |
	| Message       | Message may not be blank |
	| Subject       | Subject may not be blank |
	| Name          | Name may not be blank    |
	| Phone number  | Phone may not be blank   |

@task1
@manual
@ignore
Scenario Outline: The one where the customer enters too few or too many characters
	Given the Contact Us page is displayed
	When the customer enters a Basic Message
	But the 'field name' is 'length' characters long
		Then the message is not submitted successfully
	And the customer is informed of the 'expected' validation error

	Examples: 
	| field name   | length | reason    | expected                                        |
	| Message      | 19     | too short | Message must be between 20 and 2000 characters. |
	| Message      | 2001   | too long  | Message must be between 20 and 2000 characters. |
	| Subject      | 4      | too short | Subject must be between 5 and 100 characters.   |
	| Subject      | 101    | too long  | Subject must be between 5 and 100 characters.   |
	| Phone number | 10     | too short | Phone must be between 11 and 21 characters.     |
	| Phone number | 22     | too long  | Phone must be between 11 and 21 characters.     |