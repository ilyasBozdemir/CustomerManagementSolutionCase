Feature: Customer Management - Integration Test Scenarios

  @CreateCustomer
  Scenario: Creating a New Customer
    Given the user wants to create a new customer
    When the user accesses the customer creation functionality
    And the user provides necessary customer information
    And the user initiates the customer creation process
    Then the user should receive confirmation that the new customer has been successfully created

  @UpdatingCustomerInformation
  Scenario: Updating Customer Information
    Given the user wants to update customer information
    When the user accesses the customer editing functionality
    And the user modifies the customer's information
    And the user saves the changes
    Then the user should see the updated customer information

  @ViewingCustomerDetails
  Scenario: Viewing Customer Details
    Given the user wants to view customer details
    When the user accesses the customer details functionality
    Then the user should see the details of the selected customer

  @ListingCustomer
  Scenario: Customer Listing
    Given the user wants to view the list of customers
    When the user accesses the customer listing functionality
    Then the user should see the current list of customers

  @CustomerDeletion
  Scenario: Customer Deletion
    Given the user wants to delete a customer
    When the user accesses the customer deletion functionality
    And the user confirms the deletion
    Then the user should receive confirmation that the customer has been successfully deleted
