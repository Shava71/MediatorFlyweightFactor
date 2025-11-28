using MediatorFlyweightFactory.FlyWeight;

namespace MediatorFlyweightFactory.Models;

public class User
{
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRoleFlyweight Role { get; set; }
}