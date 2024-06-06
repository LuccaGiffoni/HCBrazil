using HCBrazil.Api.Endpoints.Attendee;

namespace HCBrazil.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");
        
        endpoints.MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "API is OK!" });

        endpoints.MapGroup("v1/attendees")
            .WithTags("Attendees")
            .MapEndpoint<CreateAttendeeEndpoint>()
            .MapEndpoint<DeleteAttendeeEndpoint>()
            .MapEndpoint<GetAllAttendeesEndpoint>()
            .MapEndpoint<GetAttendeeByIdEndpoint>()
            .MapEndpoint<UpdateAttendeeEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}