namespace User.API.Users.GetUser;

public record GetUserByIdRequest;

public record GetUserByIdResponse(Models.User User);

public class GetUserByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/users/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetUserByIdQuery(id));

                var response = result.Adapt<GetUserByIdResponse>();

                return Results.Ok(response);
            })
            .WithName("GetUesrById")
            .Produces<GetUserByIdResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get User By Id")
            .WithDescription("Get User By Id");
    }
}