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

@automated @regression
Scenario: Basic Message successful submission
	Given the Contact Us page is displayed
	When the customer enters a Basic Message
	And the customer submits the message
	Then the message is successfully submitted

@automated
Scenario: Name cannot be blank
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with an empty Name
	And the customer submits the message
	Then the customer is presented with the Blank Name validation message
	
@manual @ignore
#This test currently fails. Also the current validation error messages do not cover this scenario (missed requirement)
Scenario: Name cannot contain only numeric or special characters
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with only numeric or special characters as a Name
	And the customer submits the message
	Then the customer is presented with the Invalid Name validation message


@automated
Scenario: Email cannot be blank
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with an empty Email Address
	And the customer submits the message
	Then the customer is presented with the Blank Email validation message

@automated
Scenario Outline: Email cannot be malformed
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with a malformed email <malformed_email_address>
	And the customer submits the message
	Then the customer is presented with the Malformed Email validation message

	Examples:
	| malformed_email_address                                        |
	| Abc.example.com                                                |
	| A@b@c@example.com                                              |
	| just"not"right@example.com                                     |
	| a"b(c)d,e:f;g<h>i[j\k]l@example.com                            |
	| this is"not\allowed@example.com                                |
	| this\ still\"not\\allowed@example.com                          |
	| i_like_underscore@but_its_not_allowed_in_this_part.example.com |


@automated
Scenario: Phone Number must be between 11 and 21 characters - minimum allowed characters check
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with a Phone Number with less than minimum number of characters
	And the customer submits the message
	Then the customer is presented with the Incorrect Phone Number Length validation message

@manual @ignore
Scenario: Phone Number must be between 11 and 21 characters - maximum allowed characters check
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with a Phone Number with more than maximum number of characters
	And the customer submits the message
	Then the customer is presented with the Incorrect Phone Number Length validation message

@automated
Scenario: Subject cannot be blank
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with an empty subject
	And the customer submits the message
	Then the customer is presented with the Blank Subject validation message

@automated
Scenario Outline: Subject must be between 5 and 100 characters - minimum allowed characters check
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with a Subject with less than minimum number of characters
	And the customer submits the message
	Then the customer is presented with the Incorrect Subject Length validation message

@manual @ignore
Scenario: Subject must be between 5 and 100 characters - maximum allowed characters check
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with a Subject with more than maximum number of characters
	And the customer submits the message
	Then the customer is presented with the Incorrect Subject Length validation message
		
@manual @ignore
#This test currently fails. Also the current validation error messages do not cover this scenario (missed requirement)	 
Scenario: Subject cannot contain only numeric or special characters
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with only numeric or special characters as a Subject
	And the customer submits the message
	Then the customer is presented with the Invalid Subject validation message

@automated
Scenario: Message cannot be blank
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with an empty Message Text
	And the customer submits the message
	Then the customer is presented with the Blank Message validation message

@automated
Scenario: Message must be between 20 and 2000 characters - minimum allowed characters check
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with a Message with less than minimum number of characters
	And the customer submits the message
	Then the customer is presented with the Incorrect Message Length validation message

@manual @ignore
Scenario: Message must be between 20 and 2000 characters - maximum allowed characters check
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with a Message with more than maximum number of characters
	And the customer submits the message
	Then the customer is presented with the Incorrect Message Length validation message

@manual @ignore
#This test currently fails. Also the current validation error messages do not cover this scenario (missed requirement)
Scenario: Message cannot contain only numeric or special characterst
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with only numeric or special characters as a Message Text
	And the customer submits the message
	Then the customer is presented with the Invalid Message validation message