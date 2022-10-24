using System.ComponentModel.DataAnnotations.Schema;
using MediatR.Interface;

namespace MediatR;

public abstract class BaseEntity : IDomainEvents
{
    [NotMapped]
    private readonly IList<INotification> events = new List<INotification>();

    public IEnumerable<INotification> GetDomainEvents()
    {
        return events;
    }

    public void AddDomainEvent(INotification notification)
    {
        events.Add(notification);
    }

    public void ClearDomainEvent()
    {
        events.Clear();
    }
}