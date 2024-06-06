using HCBrazil.Core.Models;
using HCBrazil.Core.Requests.Attendees;
using HCBrazil.Core.Responses;
using HCBrazil.Core.Services;

namespace HCBrazil.Web.Services;

public class AttendeeService(IHttpClientFactory httpClientFactory) : IAttendeeService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebSettings.HttpClientName);
    
    public async Task<Response<Attendee?>> CreateAsync(CreateAttendeeRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Attendee?>> UpdateAsync(UpdateAttendeeRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Attendee?>> DeleteAsync(DeleteAttendeeRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Attendee?>> GetByIdAsync(GetAttendeeByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResponse<IEnumerable<Attendee?>>> GetAllAsync(GetAllAttendeesRequest request)
    {
        throw new NotImplementedException();
    }
}