namespace MediatorFlyweightFactory.FlyWeight.Factory;

public abstract class RoleFactoryBase
{
    public abstract UserRoleFlyweight CreateRole(string roleName);

    public UserRoleFlyweight GetRole(string roleName)
    {
        return CreateRole(roleName);
    }
}