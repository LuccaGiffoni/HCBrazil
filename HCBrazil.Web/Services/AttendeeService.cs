using System.Net.Http.Json;
using HCBrazil.Core.Models;
using HCBrazil.Core.Requests.Attendees;
using HCBrazil.Core.Responses;
using HCBrazil.Core.Services;

namespace HCBrazil.Web.Services;

public class AttendeeService(IHttpClientFactory httpClientFactory) : IAttendeeService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebSettings.HttpClientName);
    private const string BaseUri = "v1/attendees";

    public async Task<Response<Attendee?>> CreateAsync(CreateAttendeeRequest request)
    {
        var result = await _httpClient.PostAsJsonAsync(BaseUri, request);
        return await result.Content.ReadFromJsonAsync<Response<Attendee?>>()
            ?? new Response<Attendee?>(null, 400, "Falha na criação do participante.");
    }

    public async Task<Response<Attendee?>> UpdateAsync(UpdateAttendeeRequest request)
    {
        var result = await _httpClient.PutAsJsonAsync($"{BaseUri}/{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<Response<Attendee?>>()
               ?? new Response<Attendee?>(null, 400, "Falha ao atualizar o participante.");
    }

    public async Task<Response<Attendee?>> DeleteAsync(DeleteAttendeeRequest request)
    {
        var result = await _httpClient.DeleteAsync($"{BaseUri}/{request.Id}");
        return await result.Content.ReadFromJsonAsync<Response<Attendee?>>()
               ?? new Response<Attendee?>(null, 400, "Falha ao deeltar o participante.");
    }

    public async Task<Response<Attendee?>> GetByIdAsync(GetAttendeeByIdRequest request)
        => await _httpClient.GetFromJsonAsync<Response<Attendee?>>($"{BaseUri}/{request.Id}")
           ?? new Response<Attendee?>(null, 400, "Não foi possível encontrar o particpante.");

    public async Task<PagedResponse<IEnumerable<Attendee?>>> GetAllAsync(GetAllAttendeesRequest request)
        => await _httpClient.GetFromJsonAsync<PagedResponse<IEnumerable<Attendee?>>>(BaseUri)
           ?? new PagedResponse<IEnumerable<Attendee?>>(null, 400, "Não foi possível encontrar particpantes.");
}