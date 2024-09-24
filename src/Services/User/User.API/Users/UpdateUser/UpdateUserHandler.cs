namespace User.API.Users.UpdateUser;

public record UpdateUserCommand(Guid Id, string Name, string ImageFile) : ICommand<UpdateUserResult>;

public record UpdateUserResult(bool IsSuccess);

internal class UpdateUserCommandHandler(IDocumentSession session, ILogger<UpdateUserCommandHandler> logger)
    : ICommandHandler<UpdateUserCommand, UpdateUserResult>
{
    public async Task<UpdateUserResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("UpdateUserHandler.Handle called with {@Command}", command);

        var user = await session.LoadAsync<Models.User>(command.Id, cancellationToken);

        if (user is null) throw new UserNotFoundException();

        user.Name = command.Name;
        user.ImageFile = command.ImageFile;

        session.Update(user);

        await session.SaveChangesAsync(cancellationToken);

        return new UpdateUserResult(true);
    }
}