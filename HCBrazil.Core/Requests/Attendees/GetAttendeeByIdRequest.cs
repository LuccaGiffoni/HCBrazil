namespace HCBrazil.Core.Requests.Attendees;

public class GetAttendeeByIdRequest : PagedRequest
{
    public Guid Id { get; set; }
}