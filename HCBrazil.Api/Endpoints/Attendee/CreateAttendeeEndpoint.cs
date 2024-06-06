using HCBrazil.Core.Requests.Attendees;
using HCBrazil.Core.Responses;
using HCBrazil.Core.Services;

namespace HCBrazil.Api.Endpoints.Attendee;

public abstract class CreateAttendeeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/", HandleAsync)
            .WithName("Attendee: Create")
            .WithSummary("Create a new attendee")
            .WithDescription("Create a new attendee")
            .WithOrder(1)
            .Produces<Response<Core.Models.Attendee?>>()
            .WithOpenApi();
    }

    private static async Task<IResult> HandleAsync(IAttendeeService service, CreateAttendeeRequest request)
    {
        var response = await service.CreateAsync(request);
        return response.IsSuccess
            ? TypedResults.Created($"v1/attendees/{response.Data?.Id}", response)
            : TypedResults.BadRequest(response);
    }
}