﻿using System.Text.RegularExpressions;
using CustomerManagement.Domain.Seedwork;

namespace CustomerManagement.Domain.ValueObjects;

public class Email : ValueObject
{
    private string _value;

    public string Value
    {
        get { return _value; }
        set
        {
            _value = IsValidEmail(value) ? _value = value : throw new ArgumentException("Invalid email.");
        }
    }
    public Email()
    {
            
    }
    public Email(string @value)
    {
        Value = @value;   
    }
    private bool IsValidEmail(string email) => Regex.IsMatch(email, @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b");
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
