using System.Net.Http.Json;
using HCBrazil.Core.Models;
using HCBrazil.Core.Responses;
using HCBrazil.Core.Services;

namespace HCBrazil.Web.Services;

public class ViaCepService(IHttpClientFactory httpClientFactory) : IViaCepService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebSettings.HttpClientName);
    
    public async Task<Response<Address?>> GetAddressAsync(string cep)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<Address>($"https://viacep.com.br/ws/{cep}/json/");
            return new Response<Address?>(response);
        }
        catch (HttpRequestException ex)
        {
            return new Response<Address?>(null, 400, $"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return new Response<Address?>(null, 500, $"Error: {ex.Message}");
        }
    }
}
