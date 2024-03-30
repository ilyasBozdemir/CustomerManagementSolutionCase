namespace CustomerManagement.Domain.Enums;

[Flags]
public enum FilterOperator
{
    IsLessThan,// It takes values ​​less than the value given.
    IsLessThanOrEqualTo,//Retrieves values ​​less than or equal to the given one.
    IsEqualTo,//Takes those whose value is equal to the given one.
    IsNotEqualTo,// Takes those whose value is not equal to the given one.
    IsGreaterThanOrEqualTo,// Retrieves values ​​greater than or equal to the given value.
    IsGreaterThan,// It takes those whose value is greater than the given value.
    StartsWith,// Retrieves items that start with the specified text.
    EndsWith,//Retrieves items ending with the specified text.
    Contains,// Retrieves items containing the specified text.
    DoesNotContain,// Retrieves those that do not contain the specified text.
    IsNull,// Retrieves those with null values.
    IsNotNull,// Retrieves non-null values.
    IsEmpty,// It takes the empty ones.
    IsNotEmpty,// Retrieves non-empty items.
    TextSearch,// Performs text-based searches.
    IsBetween,// Retrieves events within the specified range.
    In,// Retrieves those included in the specified list.
    NotIn// Retrieves items not in the specified list.
}
