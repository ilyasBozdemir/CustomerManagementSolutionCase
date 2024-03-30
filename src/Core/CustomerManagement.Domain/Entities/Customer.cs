using CustomerManagement.Domain.Seedwork;
using CustomerManagement.Domain.ValueObjects;

namespace CustomerManagement.Domain.Entities;

using System;


public class Customer : BaseEntity
{
    public Guid Id { get; set; }
    public ValueObjects.FirstName FirstName { get; set; }
    public ValueObjects.LastName LastName { get; set; }
    public ValueObjects.Email Email { get; set; }
    public ValueObjects.DateOfBirth DateOfBirth { get; set; }
    public ValueObjects.PhoneNumber PhoneNumber { get; set; }
    public ValueObjects.BankAccountNumber BankAccountNumber { get; set; }
    public Customer()
    {

    }
    public Customer(FirstName firstName, LastName lastName, DateOfBirth dateOfBirth, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
    }

}