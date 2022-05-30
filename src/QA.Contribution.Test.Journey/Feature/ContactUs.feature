Feature: ContactUs
	As a customer
	I want to contact CustomerServices / Webmaster
	So that I can get support
	
	Description:
	A Contact Form that allows customers to send a message to Customer Servies or to the Webmaster.
	In submitting a message the customer uses the subject line to indicate the message destination (Customer Servies or to the Webmaster)
	In submitting a message the customer must provide a valid 'Email address' and a 'Messsage' body for the message to be submitted successfully to either Destination.
	In submitting a message, the customer can provide also (optionally) an 'Order reference' and upload an 'Attachment' to provide further information.
	
	Glossary:
	Destination - Either Customer Services or Webmaster
	Basic Message - A message intended for either destination that has a email adddress and a message body
	Order Query - A message intended for Customer Services that has a email address, a message body and a Order Reference, where the customer is sending a query relating to an existing order
	Techincal Support Request - A message intended for the Webmaster that has a email address, a message body and an Attachment, where the csutomer reports an issue with creating a new order
	Invalid Email Address -  An empty string
	Malformed Email Address - An email address that does not validate as an email address, e.g. missing domain

Scenario Outline: The one where the customer successfully submits a Basic Message to Customer Services or the Webmaster
	Given the Contact Us page is displayed
	When the customer enters a Basic Message intended for <destination>
	And the customer submits the message
	Then the message is successfully submitted

	Examples: Message Destination
		| destination      |
		| Customer service |
		| Webmaster        |

Scenario: The one where the customer successfully submits an Order Query
	Given the Contact Us page is displayed
	When the customer completes a Order Query message
	And the customer submits the message
	Then the message is successfully submitted

Scenario: The one where the customer successfully submits a Technical Support Request
	Given the Contact Us page is displayed
	When the customer completes a Technical Support Request message
	And the customer submits the message
	Then the message is successfully submitted

@refactor
Scenario: The one where the customer provides an invalid email address in a Techincal Support Request
	Given the Contact Us page is displayed
	When the customer completes a Techincal Support Request with an invalid email address
	And the customer submits the message
	Then the user is presented with the validation message: 'Invalid email address'

@failing
Scenario: The one where the customer provides a malformed email address in a Techincal Support Request
	Given the Contact Us page is displayed
	When the customer completes a Techincal Support Request with a malformed email address
	And the customer submits the message
	Then the user is presented with the validation message: 'Invalid email address'

Scenario: The one where the customer submits an Order Query with an empty message body
	Given the Contact Us page is displayed
	When the customer completes an Order Query with empty message body
	And the customer submits the message
	Then the user is presented with the validation message: 'The message cannot be blank'

@manual @ignore
Scenario: The one where the customer submits a message with an attachment that is too large
	Given the Contact Us page is displayed
	When the customer submits a Technical Support Request message with an attachment that is too large
	Then the message is not submitted successully

@manual @ignore
Scenario: The one where the customer submits a message with a message body that is too large
	Given the Contact Us page is displayed
	When the customer submits an Order Query message with a message body that is too large
	Then the website displays an error 500

