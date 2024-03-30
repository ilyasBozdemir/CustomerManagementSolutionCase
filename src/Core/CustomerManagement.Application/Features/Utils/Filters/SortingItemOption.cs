using CustomerManagement.Application.Features.Utils.Filters.Enums;

namespace CustomerManagement.Application.Features.Utils.Filters;
public class SortingItemOption
{
    public string PropertyName { get; set; } // Feature name to sort
    public SortingDirection Direction { get; set; } // Sort method (Ascending or Descending)
    public IQueryable<T> ApplySorting<T>(IQueryable<T> query)
    {
        if (Direction == SortingDirection.Ascending)
            return query.OrderBy(item => item.GetType().GetProperty(PropertyName).GetValue(item, null));
        else
            return query.OrderByDescending(item => item.GetType().GetProperty(PropertyName).GetValue(item, null));
    }
}
