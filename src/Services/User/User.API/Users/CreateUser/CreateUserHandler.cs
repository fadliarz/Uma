namespace User.API.Users.CreateUser;

public record CreateUserCommand(string Email, string Password, string Name, string ImageFile)
    : ICommand<CreateUserResult>;

public record CreateUserResult(Guid Id);

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required!");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required!");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required!");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required!");
    }
}

internal class CreateUserCommandHandler(IDocumentSession session)
    : ICommandHandler<CreateUserCommand, CreateUserResult>
{
    public async Task<CreateUserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = new Models.User
        {
            Email = command.Email,
            Password = command.Password,
            Name = command.Name,
            ImageFile = command.ImageFile
        };

        session.Store(user);

        await session.SaveChangesAsync(cancellationToken);

        return new CreateUserResult(user.Id);
    }
}