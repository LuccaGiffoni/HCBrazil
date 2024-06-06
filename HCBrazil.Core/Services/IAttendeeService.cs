using HCBrazil.Core.Models;
using HCBrazil.Core.Requests.Attendees;
using HCBrazil.Core.Responses;

namespace HCBrazil.Core.Services;

public interface IAttendeeService
{
    Task<Response<Attendee?>> CreateAsync(CreateAttendeeRequest request);
    Task<Response<Attendee?>> UpdateAsync(UpdateAttendeeRequest request);
    Task<Response<Attendee?>> DeleteAsync(DeleteAttendeeRequest request);
    Task<Response<Attendee?>> GetByIdAsync(GetAttendeeByIdRequest request);
    Task<PagedResponse<IEnumerable<Attendee?>>> GetAllAsync(GetAllAttendeesRequest request);
}