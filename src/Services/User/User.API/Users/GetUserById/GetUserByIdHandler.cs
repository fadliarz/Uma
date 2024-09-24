namespace User.API.Users.GetUser;

public record GetUserByIdQuery(Guid Id) : IQuery<GetUserByIdResult>;

public record GetUserByIdResult(Models.User User);

internal class GetUserByIdQueryHandler(IDocumentSession session, ILogger<GetUserByIdQueryHandler> logger)
    : IQueryHandler<GetUserByIdQuery, GetUserByIdResult>
{
    public async Task<GetUserByIdResult> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetUserQueryHandler.Handle called with {@Query}", query);

        var user = await session.LoadAsync<Models.User>(query.Id, cancellationToken);

        if (user is null) throw new UserNotFoundException();

        return new GetUserByIdResult(user);
    }
}