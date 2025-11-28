using MediatorFlyweightFactory.FlyWeight.Factory;
using MediatorFlyweightFactory.Models;

namespace MediatorFlyweightFactory.Mediator;

public class Mediator : IMediator
{
    private readonly ILogger<Mediator> _logger;
    private readonly RoleFactory _roleFactory;

    public Mediator(ILogger<Mediator> logger, RoleFactory roleFactory)
    {
        _logger = logger;
        _roleFactory = roleFactory;
    }
    
    public TResponse Request<TResponse>(string evt, object? data = null)
    {
        switch (evt)
        {
            case "GetRole":
                string roleName = data!.ToString()!;
                var role = _roleFactory.GetRole(roleName);
                _logger.LogInformation($"Role requested: {role.Name}");
                return (TResponse)(object)role;

            default:
                throw new InvalidOperationException($"Unknown Request event: {evt}");
        }
    }

    public void Notify(string evt, object? data = null)
    {
        switch (evt)
        {
            case "UserRegistered":
                var user = (User)data!;
                _logger.LogInformation($"New user registered: {user.Email}");
                break;

            default:
                _logger.LogWarning($"Unknown Notify event: {evt}");
                break;
        }
    }
}