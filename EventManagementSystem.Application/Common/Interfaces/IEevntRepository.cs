using EventManagementSystem.Domain.Entities;

namespace EventManagementSystem.Application.Common.Interfaces
{
    public interface IEevntRepository : IRepository<Event>
    {
        void Update(Event entity);

    }
}
