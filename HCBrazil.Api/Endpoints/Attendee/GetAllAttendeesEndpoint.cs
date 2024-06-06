using HCBrazil.Core;
using HCBrazil.Core.Requests.Attendees;
using HCBrazil.Core.Responses;
using HCBrazil.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace HCBrazil.Api.Endpoints.Attendee;

public class GetAllAttendeesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Attendees: Get all")
            .WithSummary("Return all attendees paged")
            .WithDescription("Return all attendees paged")
            .WithOrder(4)
            .Produces<PagedResponse<List<Core.Models.Attendee?>>>();

    private static async Task<IResult> HandleAsync(IAttendeeService service,
        [FromQuery] int pageNumber = Settings.DefaultPageNumber, 
        [FromQuery] int pageSize = Settings.DefaultPageSize)
    {
        var request = new GetAllAttendeesRequest
        {
            PageSize = pageSize,
            PageNumber = pageNumber
        };
        
        var response = await service.GetAllAsync(request);
        return response.IsSuccess
            ? TypedResults.Ok(response)
            : TypedResults.BadRequest(response);
    }
}