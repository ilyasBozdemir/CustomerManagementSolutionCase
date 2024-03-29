using System.Text.RegularExpressions;
using CustomerManagement.Domain.Seedwork;

namespace CustomerManagement.Domain.ValueObjects;

public class BankAccountNumber : ValueObject
{
    private string _value;
    public string Value 
    {
        get { return _value; }
        set
        {
            _value  = IsValidBankAccountNumber(value) ? _value = value : throw new ArgumentException("Invalid bank account number.");
        }
    }
    public BankAccountNumber()
    {

    }
    public BankAccountNumber(string @value)
    {
        Value = @value;
    }
    private bool IsValidBankAccountNumber(string accountNumber) => !string.IsNullOrWhiteSpace(accountNumber) && Regex.IsMatch(accountNumber, @"^\d{10,}$");

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
