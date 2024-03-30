namespace CustomerManagement.Application.Features.Utils.Filters.Enums;

[Flags]
public enum FilterOperator
{
    IsLessThan, // Gets values ​​less than the given one.
    IsLessThanOrEqualTo, // Gets values ​​less than or equal to the given one.
    IsEqualTo, // Gets values ​​equal to the given one.
    IsNotEqualTo, // Gets the values ​​whose value is not equal to the given one.
    IsGreaterThanOrEqualTo, // Gets values ​​greater than or equal to the given one.
    IsGreaterThan, // Gets values ​​greater than the given one.
    StartsWith,// Gets starts with the specified text.
    EndsWith,// Gets endings with the specified text.
    Contains, // Gets the contents containing the specified text.
    DoesNotContain, // Gets what does not contain the specified text.
    IsNull, // Gets values ​​that are null.
    IsNotNull, // Gets non-null values.
    IsEmpty, // Gets empty ones.
    IsNotEmpty, // Gets non-empty items.
    TextSearch, // Performs text-based searches.
    IsBetween, // Gets events in the specified range.
    In,// Retrieves items included in the specified list.
    NotIn// Gets items not in the specified list.
}