﻿Feature: ContactUs
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
	Blank Phone Number - An empty string
	Short Phone Number - Less than 11 digits
	Long Phone Number - More than 22 digits
	Blank Subject - An empty string
	Short Subject - Less than 5 Characters 
	Blank Name - An empty string
	Malformed Email Address - An email address that does not validate as an email address, e.g. missing domain


Scenario: The one where the customer submits a Blank Name
	Given the Contact Us page is displayed
	When the customer types a empty string into the name field
	And the customer submits the message
	Then the message is not submitted successfully
	And the customer is informed of the name validation error

Scenario: The one where the customer submits a Short Subject
	Given the Contact Us page is displayed
	When the customer types a short string into the subject field
	And the customer submits the message
	Then the message is not submitted successfully
	And the customer is informed of the subject validation error


Scenario: The one where the customer submits a Blank Subject
	Given the Contact Us page is displayed
	When the customer types an empty string into the subject field
	And the customer submits the message
	Then the message is not submitted successfully
	And the customer is informed of the subject validation error


Scenario: The one where the customer submits a Long Phone Number
	Given the Contact Us page is displayed
	When the customer types a long string into the phone number field
	And the customer submits the message
	Then the message is not submitted successfully
	And the customer is informed of the phone validation error


Scenario: The one where the customer submits a Blank Phone Number
	Given the Contact Us page is displayed
	When the customer types an empty string into the phone number field
	And the customer submits the message
	Then the message is not submitted successfully
	And the customer is informed of the phone validation error

Scenario: The one where the customer submits a Short Phone Number
	Given the Contact Us page is displayed
	When the customer types a short string into the phone number field
	And the customer submits the message
	Then the message is not submitted successfully
	And the customer is informed of the phone validation error

Scenario: The one where the customer successfully submits a Basic Message
	Given the Contact Us page is displayed
	When the customer enters a Basic Message
	And the customer submits the message
	Then the message is successfully submitted

@manual@ignore
Scenario: The one where the customer clicks Book This Room
	Given the Contact Us page is displayed
	When the customer clicks Book This Room
	Then the calander is successfully displayed

@refactor
Scenario: The one where the customer provides an invalid email address
	Given the Contact Us page is displayed
	When the customer types an empty string into the email address field
	And the customer submits the message
	Then the message is not submitted successfully
	And the customer is informed of the email validation error

@failing
Scenario: The one where the customer provides a malformed email address
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with a malformed email address
	And the customer submits the message
	Then the customer is presented with the correct validation message