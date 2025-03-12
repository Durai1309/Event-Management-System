using EventManagementSystem.Domain.Entities;

namespace EventManagementSystem.Application.Common.Interfaces
{
    public interface IEventDetailRepository : IRepository<EventDetail>
    {
        void Update(EventDetail entity);
    }
}
