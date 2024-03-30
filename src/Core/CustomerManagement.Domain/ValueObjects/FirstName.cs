
using CustomerManagement.Domain.Seedwork;

namespace CustomerManagement.Domain.ValueObjects;

public class FirstName : ValueObject
{
    public string Value { get; }

    public FirstName() { }
    public FirstName(string @value)
    {
        Value = @value;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
       yield return Value;
    }
}
