namespace HCBrazil.Core.Requests;

public abstract class PagedRequest : Request
{
    public int PageSize { get; set; } = Settings.DefaultPageSize;
    public int PageNumber { get; set; } = Settings.DefaultPageNumber;
}