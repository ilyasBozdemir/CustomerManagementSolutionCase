Feature: Customer Management


  @CreateCustomer
  Scenario: Creating a New Customer
    Given The user opens the application and enters the address '/Customer/Index'.
    When the user chooses to create a new customer.
    And the user enters the new customer's name as 'John'.
    And the user enters the new customer's last name as 'Doe'.
    And The user enters the new customer's date of birth as '01.01.1990'.
    And The user enters the new customer's phone number as '+905553331122'.
    And the user enters the new customer's email address as 'john.doe@example.com'.
    And The user enters the new customer's bank account number as '1234567890'.
    And The user confirms that the new customer has been created.
    Then the user sees that the new customer has been successfully created.


  @UpdatingCustomerInformation
  Scenario: Updating Customer Information
    Given the user opens the application and enters the address '/Edit/{customer-id}'.
    When the user selects a customer from the customer list.
    And the user chooses to update customer information.
    And the user updates the customer's name to 'Jane'.
    And the user updates the customer's last name to 'Smith'.
    And the user confirms the update process.
    Then the user sees updated customer information.

  @ViewingCustomerDetails
  Scenario: Viewing Customer Details
    Given the user opens the application and enters the address '/Customer/Details/{customer-id}'.
    When the user selects a customer from the customer list.
    And the user chooses to view the details of the customer.
    Then the user sees the details of the selected customer.

  @ListingCustomer
  Scenario: Customer Listing
    Given The user opens the application and enters the address '/Customer/Index'.
    When The user chooses to view the customer list.
    Then the user sees the current customer list.

  @CustomerDeletion
  Scenario: Customer Deletion
    Given The user opens the application and enters the address '/Customer/Index'.
    When The user selects a customer from the customer list.
    And the user chooses to delete the customer.
    And The user confirms the deletion.
    Then the user sees that the customer has been successfully deleted.