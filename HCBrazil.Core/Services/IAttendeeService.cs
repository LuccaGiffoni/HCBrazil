using HCBrazil.Core.Models;
using HCBrazil.Core.Requests.Attendees;
using HCBrazil.Core.Responses;

namespace HCBrazil.Core.Services;

public interface IAttendeeService
{
    Task<Response<Attendee>> CreateWithExistingGuardianAsync(CreateAttendeeWithExistingGuardianRequest request);
    Task<Response<Attendee>> CreateWithNewGuardianAsync(CreateAttendeeWithNewGuardianRequest request);
    Task<Response<Attendee>> UpdateAsync(UpdateAttendeeRequest request);
    Task<Response<Attendee>> DeleteAsync(DeleteAttendeeRequest request);
    Task<Response<Attendee>> GetByIdAsync(GetAttendeeByIdRequest request);
    Task<Response<IEnumerable<Attendee>>> GetAllAsync(GetAllAttendeesRequest request);
}