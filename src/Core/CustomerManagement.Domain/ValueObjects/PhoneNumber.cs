using CustomerManagement.Domain.Seedwork;

namespace CustomerManagement.Domain.ValueObjects;

public class PhoneNumber : ValueObject
{
    private string _value;
    public string Value 
    {
        get { return _value; }
        set
        {
            _value = IsValidPhoneNumber(value) ? _value = value : throw new ArgumentException("Invalid phone number.");
        }
    }

    public PhoneNumber()
    {
            
    }
    public PhoneNumber(string @value)
    {
        Value = @value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }

    private bool IsValidPhoneNumber(string phoneNumber)
    {

        PhoneNumbers. PhoneNumberUtil phoneNumberUtil = PhoneNumbers. PhoneNumberUtil.GetInstance();
        try
        {
            PhoneNumbers.PhoneNumber number = phoneNumberUtil.Parse(phoneNumber, null);
            return phoneNumberUtil.IsValidNumber(number) &&
                   phoneNumberUtil.GetNumberType(number) == PhoneNumbers.PhoneNumberType.MOBILE;

        }
        catch (PhoneNumbers.NumberParseException)
        {
            return false;
        }
    }
}
