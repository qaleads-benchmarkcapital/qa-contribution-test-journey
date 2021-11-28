Feature: ContactUs

	Scenario: The one where the customer successfully submits a Basic Message to Customer Services or the Webmaster
		Given the Contact Us page is displayed
		When the customer enters a Basic Message intended for "Customer service"
		And the customer submits the message
		Then the message is successfully submitted

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

	Scenario: The one where the Subject Heading is not selected
		Given the Contact Us page is displayed
		When the form is completed without the Subject Heading
		And the customer submits the message
		Then the missing Subject Heading warning is shown

	Scenario: The one where no email address is entered
		Given the Contact Us page is displayed
		When the form is completed without an email
		And the customer submits the message
		Then the invalid email warning is shown

	Scenario: The one where an invalid email address is entered
		Given the Contact Us page is displayed
		When the form is completed with an invalid email
		And the customer submits the message
		Then the invalid email warning is shown

	Scenario: The one where a blank form is submitted
		Given the Contact Us page is displayed
		And the customer submits the message
		Then the invalid email warning is shown

