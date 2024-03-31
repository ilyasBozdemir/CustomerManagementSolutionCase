Feature: Customer Management

  Scenario: Creating a New Customer
    Given the user opens the application
    When the user selects to create a new customer
    And the user enters the name of the new customer as "John"
    And the user enters the last name of the new customer as "Doe"
    And the user enters the date of birth of the new customer as "01.01.1990"
    And the user enters the phone number of the new customer as "1234567890"
    And the user enters the email address of the new customer as "john.doe@example.com"
    And the user enters the bank account number of the new customer as "1234567890"
    And the user confirms the creation of the new customer
    Then the user sees that the new customer has been successfully created
