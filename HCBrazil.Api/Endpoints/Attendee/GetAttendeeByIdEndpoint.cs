using HCBrazil.Core.Requests.Attendees;
using HCBrazil.Core.Responses;
using HCBrazil.Core.Services;

namespace HCBrazil.Api.Endpoints.Attendee;

public abstract class GetAttendeeByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Attendees: Get by ID")
            .WithSummary("Return one attendee")
            .WithDescription("Return one attendee")
            .WithOrder(3)
            .Produces<Response<Core.Models.Attendee?>>()
            .WithOpenApi(getAttendee =>
            {
                var attendeeId = getAttendee.Parameters[0];
                attendeeId.Description = "The ID of the attendee to be found";
                
                return getAttendee;
            });

    private static async Task<IResult> HandleAsync(IAttendeeService service, Guid id)
    {
        var request = new GetAttendeeByIdRequest
        {
            Id = id
        };

        var result = await service.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}