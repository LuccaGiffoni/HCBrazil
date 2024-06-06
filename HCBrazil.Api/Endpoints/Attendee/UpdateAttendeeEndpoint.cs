﻿using HCBrazil.Core.Requests.Attendees;
using HCBrazil.Core.Responses;
using HCBrazil.Core.Services;

namespace HCBrazil.Api.Endpoints.Attendee;

public class UpdateAttendeeEndpoint: IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Attendees: Update")
            .WithSummary("Update one attendee")
            .WithDescription("Update one attendee")
            .WithOrder(5)
            .Produces<Response<Core.Models.Attendee?>>();
    
    private static async Task<IResult> HandleAsync(IAttendeeService service,
        UpdateAttendeeRequest request, Guid id)
    {
        request.Id = id;

        var result = await service.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}