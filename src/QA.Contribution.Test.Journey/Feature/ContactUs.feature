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
	Then customer enters valid values in text field of form
	| name | email       | phone       | subject           | message             |
	| Gilu | gilu@gd.com | 07567890087 | website got frozen| please contact asap |
	Then the message is successfully submitted

@refactor
Scenario: The one where the customer provides an invalid email address
	Given the Contact Us page is displayed
	When the customer types an empty string into the email address field
	And the user types a message into the message body field like as below
	| name | phone       | subject                   | message |
	| Gilu |  07567890087| Website got frozen        |  please contact asap       |
	And the customer submits the message
	Then the message is not submitted successfully
	And the customer is informed of the email validation error
	Then warning message for empty mail address will be displayed
	
	

@failing
Scenario: The one where the customer provides a malformed email address
	Given the Contact Us page is displayed
	When the customer completes a Basic Message with a malformed email address
	Then the user is presented with the correct validation message

Scenario: The customer enters name
 Given the contact Us page is displayed
 When the customer enters name
 Then validate if the name accepts valid names
 And if customer enters invalid name proper warning message field is displaying
 Then validate the name fields accepts alphanumeric values,if the name is customixed,validate that
 And validate whether the form rejects invalid name(~67"+)
 
 

 Scenario:The customer enters email
 Given the customer is on contact Us page
 When the customer enters email address
 Then if it doesnt contains @ symbol,display validation error message
 And display warning message for inavlid email address

 Scenario:The customer enters phone number
 Given The customer is on contact us page
 When the customer enters phone number
 Then validate if the phone number is according to countrys right number of digits
 And validate if the phone number contain proper country code
 Then display error if wrong code
 And validate only numbers are accepted in input field
 And valdate for negative number fields
 Then validate by entering more digits than actaul number of digits
 And validate if space between mobile number or not
 Then validate if mobile number is saved by pressing enter button after entering mobile number

 Scenario:The customer enters subject
 Given the customer is on contact Us page
 When the customer enters the subject
 Then Validate if customer is able to enter maximum message in text field or not
 And validate if customer is bale to enter minimum length in message field or not
 Then validate if customer is able to enter alphanumeric entries
 And validate if any character limit for the filed

 Scenario:The customer enters message
 Given The customer is on contact us page
 When the customer enters message
 Then validate if the message field accepts minium number of characters in filed
 And VAlidate if message filed accepts maximum number of characters
 Then validate keyboard operations will work in message filed
 And proper warning message should be displayed if customer submits without entering message
 Then validate spelling checks in message field
 
 Scenario: The customer clicks submit button
 Given The customer is on contact us form page
 When The customer clicks submit
 And validate spelling and position of submit button are right
 Then submit button is clickable
 And when submitting form,the value gets saved and admin receives same
 And valiadte success message displayed or not

 Scenario: The message body is present or not
 Given The customer is on contact us page
 Then validate whether message body is present
 And if body is not present,display warning message

 Scenario: The customer send contact us form without email address
 Given the customer is on contact Us page
 When the customer send message without email address
 Then given warning message without email address message cant be send

 Scenario:The customer send contact us form without message body and email addres,validate whether submit will work or not
 Given The customer is on contact Us form page
 When the customer click submit without giving messgae body or email address
 Then proper warning message should be displayed
 @maual
 Scenario:The customer clicks on any field the cursor should display in text field
 Given The customer is on contact Us form page
 When user clicks on text field
 Then cursor should be displayed

 @manual
 Scenario:The customer is able to enter minium
 @manual
 Scenario:The image or icon is present before each field on left side
 @manual
 Scenario:Time out functionality
 Validate page behaves when customer loads page for long time

 @manual
 Scenario:validate text on all fields for spelling and grammatical errors
 Scenario:Gui and usability 
 All field on page should be displayed properly
 Enough space should be provided between text,rows,error messages
 Scroll bar should be enabled only when neccessary
 On clicking text field ,the arrow pointyer should get changed to cursor
 Tab and shift+Tab should work properly
 All buttons on page should be accesible with keyborad shortcuts
 Verify lenght,width,height,color of all text input fields
 Verify customer is able to enter maximum length in name field or not
 Verify customer is able to enter minimum lenght in name field or not
 Verify if text field accept both upper acse and lower case
 verify if text fields accep spaces as input
 verify minimum and maximum of lll text fields
 Verify copy paste long words from word or notepad accepted or not
 verify cookies are saved properly
 @databaseTesting
 Check if correct data is getting saved in database upon successful page submit
 Check if values for rows are not accepting null values
 Validate if input data saved are not truncated while on clicking submit button.The text field length shown to user on page and database should be same

 