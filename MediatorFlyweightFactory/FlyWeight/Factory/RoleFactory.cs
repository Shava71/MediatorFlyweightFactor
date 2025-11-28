namespace MediatorFlyweightFactory.FlyWeight.Factory;

public class RoleFactory : RoleFactoryBase
{
    private readonly Dictionary<string, UserRoleFlyweight> _roles = new(); // кэш
    public override UserRoleFlyweight CreateRole(string roleName)
    {
        if (_roles.ContainsKey(roleName))
            return _roles[roleName];
        
        UserRoleFlyweight role = roleName switch
        {
            "JobSeeker" => new UserRoleFlyweight("JobSeeker",
                new[] { "PostResume", "SeeVacancy", "MakeFeedback", "Calling", "Chatting", }),

            "Company" => new UserRoleFlyweight("Company",
                new[] { "PostJob", "SeeResume", "MakeFeedback", "Calling", "Chatting", }),

            "Admin" => new UserRoleFlyweight("Admin",
                new[] { "ManageUsers", "Moderate" }),

            _ => new UserRoleFlyweight("Guest",
                new[] { "SeeResume", "SeeVacancy" })
        };

        _roles[roleName] = role; // кэшируем
        return role;
    }
}