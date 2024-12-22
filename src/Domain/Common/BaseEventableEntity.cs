using TaskManagement.Domain.Abstractions;

namespace TaskManagement.Domain.Common
{
    public interface IEventableEntity
    {
        IReadOnlyList<IDomainEvent> GetDomainEvents();
        void ClearDomainEvents();
        void AddDomainEvent(IDomainEvent domainEvent);
    }
}
