namespace MediatorFlyweightFactory.Mediator;

public interface IMediator
{
    TResponse Request<TResponse>(string evt, object? data = null);
    void Notify(string evt, object? data = null);
}