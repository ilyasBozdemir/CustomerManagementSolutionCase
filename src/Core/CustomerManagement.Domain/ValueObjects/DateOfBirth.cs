
using CustomerManagement.Domain.Seedwork;

namespace CustomerManagement.Domain.ValueObjects;

public class DateOfBirth: ValueObject
{
    public DateTime Value { get; }

    
    public DateOfBirth()
    {

    }
    public DateOfBirth(DateTime @value)
    {
        Value = @value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
       yield return Value;
    }
}
