using EventManagementSystem.Domain.Entities;

namespace EventManagementSystem.Application.Common.Interfaces
{
    public interface IEventNumberRepository : IRepository<EventNumber>
    {
        void Update(EventNumber entity);
    }
}
