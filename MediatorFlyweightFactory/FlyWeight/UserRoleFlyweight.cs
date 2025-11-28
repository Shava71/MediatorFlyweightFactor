namespace MediatorFlyweightFactory.FlyWeight;

public class UserRoleFlyweight
{
    public string Name { get; }
    public IReadOnlyList<string> Permissions { get; }

    public UserRoleFlyweight(string name, IEnumerable<string> permissions)
    {
        Name = name;
        Permissions = permissions.ToList();
    }

    public void Print() => Console.WriteLine($"Role: {Name} | Permissions: {string.Join(", ", Permissions)}");
}