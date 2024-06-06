using HCBrazil.Core.Requests.Attendees;
using HCBrazil.Core.Responses;
using HCBrazil.Core.Services;

namespace HCBrazil.Api.Endpoints.Attendee;

public class DeleteAttendeeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Attendee: Delete")
            .WithSummary("Delete an Attendee by ID")
            .WithDescription("Delete an Attendee by ID")
            .WithOrder(2)
            .Produces<Response<Core.Models.Attendee?>>();

    private static async Task<IResult> HandleAsync(IAttendeeService service, Guid id)
    {
        var request = new DeleteAttendeeRequest
        {
            Id = id
        };

        var result = await service.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}