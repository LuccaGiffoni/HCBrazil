using HCBrazil.Core.Requests.Attendees;
using HCBrazil.Core.Responses;
using HCBrazil.Core.Services;

namespace HCBrazil.Api.Endpoints.Attendee;

public class CreateAttendeeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Attendee: Create")
            .WithSummary("Create a new Attendee")
            .WithDescription("Create a new Attendee")
            .WithOrder(1)
            .Produces<Response<Core.Models.Attendee?>>();

    private static async Task<IResult> HandleAsync(IAttendeeService service, CreateAttendeeRequest request)
    {
        var response = await service.CreateAsync(request);
        return response.IsSuccess
            ? TypedResults.Created($"v1/attendees/{response.Data?.Id}", response)
            : TypedResults.BadRequest(response);
    }
}