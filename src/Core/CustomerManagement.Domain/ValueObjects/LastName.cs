
using CustomerManagement.Domain.Seedwork;

namespace CustomerManagement.Domain.ValueObjects;

public class LastName : ValueObject
{
    public string Value { get; }

    public LastName()
    {
        
    }
    public LastName(string @value)
    {
        Value = @value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
