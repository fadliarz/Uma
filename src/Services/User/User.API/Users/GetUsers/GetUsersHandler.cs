namespace User.API.Users.GetUsers;

public record GetUsersQuery : IQuery<GetUsersResult>;

public record GetUsersResult(IEnumerable<Models.User> Users);

internal class GetUsersQueryHandler(IDocumentSession session, ILogger<GetUsersQueryHandler> logger)
    : IQueryHandler<GetUsersQuery, GetUsersResult>
{
    public async Task<GetUsersResult> Handle(GetUsersQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetUsersQueryHandler.Handle called with {@Query}", query);

        var users = await session.Query<Models.User>().ToListAsync(cancellationToken);

        return new GetUsersResult(users);
    }
}