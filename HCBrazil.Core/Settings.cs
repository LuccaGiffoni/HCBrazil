namespace HCBrazil.Core;

public static class Settings
{
    public const int DefaultPageNumber = 1;
    public const int DefaultPageSize = 15;
    public const int DefaultStatusCode = 200;
    public const int DefaultCurrentPage = 1;

    public static string BackendUrl { get; set; } = "http://localhost:5257";
    public static string FrontendUrl { get; set; } = "http://localhost:5223";
}