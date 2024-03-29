namespace CustomerManagement.Application.Features.Wrappers.Paging;

public class Paginate<T>
{
    public Paginate()
    {
        Items = Array.Empty<T>();
    }
    public int PageSize { get; set; }
    public int CurrentPageIndex { get; set; }
    public int Count { get; set; }
    public int Pages { get; set; }
    public IList<T> Items { get; set; }

    public bool HasPrevious => CurrentPageIndex > 0;
    public bool HasNext => CurrentPageIndex + 1 < Pages;
}
