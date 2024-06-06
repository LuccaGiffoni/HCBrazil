using System.Text.Json.Serialization;

namespace HCBrazil.Core.Responses;

public class Response<TData>
{
    private int _httpCode;
    
    public TData? Data { get; set; }
    public string? Message { get; set; }

    [JsonIgnore] public bool IsSuccess => _httpCode is >= 200 and <= 299;

    [JsonConstructor] public Response() => _httpCode = Settings.DefaultStatusCode;
    
    public Response(TData? data, int httpCode = Settings.DefaultStatusCode, string? message = null)
    {
        Data = data;
        Message = message;
        this._httpCode = httpCode;
    }
}