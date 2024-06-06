using HCBrazil.Core.Requests.Attendees;
using HCBrazil.Core.Responses;
using HCBrazil.Core.Services;

namespace HCBrazil.Api.Endpoints.Attendee;

public abstract class DeleteAttendeeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithOpenApi()
            .WithName("Attendee: Delete")
            .WithSummary("Delete an attendee by ID")
            .WithDescription("Delete an attendee by ID")
            .WithOrder(2)
            .Produces<Response<Core.Models.Attendee?>>()
            .WithOpenApi(attendeeToDelete =>
            {
                var parameter = attendeeToDelete.Parameters[0];
                parameter.Description = "The ID to delete from database";
                return attendeeToDelete;
            });

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