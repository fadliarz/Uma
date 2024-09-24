namespace Trip.API.Trips.GetTrips;

public record GetTripsResponse(IEnumerable<TripModel> Trips);

public class GetTripsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/trips/{userName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new GetTripsQuery(userName));

            var response = result.Adapt<IEnumerable<TripModel>>();

            return Results.Ok(response);
        });
    }
}