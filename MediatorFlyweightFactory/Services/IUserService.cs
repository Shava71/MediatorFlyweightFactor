using MediatorFlyweightFactory.Models;

namespace MediatorFlyweightFactory.Services;

public interface IUserService
{
    Task<User> Register(string email, string password, string roleName);
}