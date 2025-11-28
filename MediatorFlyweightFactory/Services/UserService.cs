using MediatorFlyweightFactory.FlyWeight;
using MediatorFlyweightFactory.Mediator;
using MediatorFlyweightFactory.Models;

namespace MediatorFlyweightFactory.Services;

public class UserService : IUserService
{
    private readonly IMediator _mediator;

    public UserService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task<User> Register(string email, string password, string roleName)
    {
        var newUser = new User
        {
            Email = email,
            Password = password
        };
        
        var role = _mediator.Request<UserRoleFlyweight>("GetRole", roleName);
        newUser.Role = role;
        
        _mediator.Notify("UserRegistered", newUser);

        return Task.FromResult(newUser);
    }
}