using HCBrazil.Core.Requests.Attendees;
using HCBrazil.Core.Responses;
using HCBrazil.Core.Services;

namespace HCBrazil.Api.Endpoints.Attendee;

public class GetAttendeeByIdEnpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Attendess: Get by ID")
            .WithSummary("Return one attendee")
            .WithDescription("Return one attendee")
            .WithOrder(3)
            .Produces<Response<Core.Models.Attendee?>>();

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