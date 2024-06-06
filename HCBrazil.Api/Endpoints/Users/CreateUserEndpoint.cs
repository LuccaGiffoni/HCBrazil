using HCBrazil.Core.Requests.Attendees;
using HCBrazil.Core.Responses;
using HCBrazil.Core.Services;

namespace HCBrazil.Api.Endpoints.Users;

public class CreateUserEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("User: Create")
            .WithSummary("Create a new User")
            .WithDescription("Create a new User")
            .WithOrder(1)
            .Produces<Response<Core.Models.ApplicationUser?>>();

    private static async Task<IResult> HandleAsync(IAttendeeService service, CreateAttendeeRequest request)
    {
        var response = await service.CreateAsync(request);
        return response.IsSuccess
            ? TypedResults.Created($"v1/attendees/{response.Data?.Id}", response)
            : TypedResults.BadRequest(response);
    }
}