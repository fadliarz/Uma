namespace Trip.API.Trips.GetTrips;

public record GetTripsQuery(string UserName) : IQuery<GetTripsResult>;

public record GetTripsResult(IEnumerable<TripModel> Trips);

public class GetTripsHandler : IQueryHandler<GetTripsQuery, GetTripsResult>
{
    public async Task<GetTripsResult> Handle(GetTripsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}