namespace MediatR.Interface;

public interface IDomainEvents
{
    IEnumerable<INotification> GetDomainEvents();

    void AddDomainEvent(INotification notification);

    void ClearDomainEvent();
}