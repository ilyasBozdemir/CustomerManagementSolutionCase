Feature: Customer Management

  @CreateCustomer
  Scenario: Creating a New Customer
    Given The user opens the application and enters the address 'https://localhost:7189/Customer/Index'.
    When the user chooses to create a new customer.
    And the user enters the new customer's name as 'John'.
    And the user enters the new customer's last name as 'Doe'.
    And The user enters the new customer's date of birth as '01.01.1990'.
    And The user enters the new customer's phone number as '1234567890'.
    And the user enters the new customer's email address as 'john.doe@example.com'.
    And The user enters the new customer's bank account number as '1234567890'.
    And The user confirms that the new customer has been created.
    Then the user sees that the new customer has been successfully created.

  @ListingCustomer
  Scenario: Customer Listing
    Given The user opens the application and enters the address 'https://localhost:7189/Customer/Index'.
    When The user chooses to view the customer list.
    Then the user sees the current customer list.

  @ViewingCustomerDetails
  Scenario: Viewing Customer Details
    Given The user opens the application and enters the address 'https://localhost:7189/Customer/Details/{customer-id}'.
    When The user selects a customer from the customer list.
    And the user chooses to view the details of the customer.
    Then the user sees the details of the selected customer.


  @UpdatingCustomerInformation
  Scenario: Updating Customer Information
    Given The user opens the application and enters the address 'https://localhost:7189/Edit/{customer-id}'.
    When The user selects a customer from the customer list.
    And the user chooses to update customer information.
    And The user updates the customer's name to 'Jane'.
    And The user updates the customer's last name to 'Smith'.
    And The user confirms the update process.
    Then the user sees updated customer information.

  @CustomerDeletion
  Scenario: Customer Deletion
    Given The user opens the application and enters the address 'https://localhost:7189/Customer/Index'.
    When The user selects a customer from the customer list.
    And the user chooses to delete the customer.
    And The user confirms the deletion.
    Then the user sees that the customer has been successfully deleted.

