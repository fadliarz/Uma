namespace User.API.Models;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
}