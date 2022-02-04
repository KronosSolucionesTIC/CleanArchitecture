using CleanArchitecth.Domain.Common;

namespace CleanArchitecth.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
