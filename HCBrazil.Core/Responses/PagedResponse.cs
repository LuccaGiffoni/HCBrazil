using System.Text.Json.Serialization;

namespace HCBrazil.Core.Responses;

public class PagedResponse<TData> : Response<TData>
{
    public int CurrentPage { get; set; } = Settings.DefaultCurrentPage;
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

    public int PageSize { get; set; } = Settings.DefaultPageSize;
    public int TotalCount { get; set; }
    
    [JsonConstructor]
    public PagedResponse(TData? data, int totalCount,
        int currentPage = Settings.DefaultCurrentPage, int pageSize = Settings.DefaultPageSize) : base(data)
    {
        Data = data;
        TotalCount = totalCount;
        PageSize = pageSize;
        CurrentPage = currentPage;
    }

    public PagedResponse(TData? data, int httpCode = Settings.DefaultStatusCode, string? message = null)
        : base(data, httpCode, message)
    {
    }
}