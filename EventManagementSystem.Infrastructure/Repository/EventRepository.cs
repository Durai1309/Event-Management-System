using EventManagementSystem.Application.Common.Interfaces;
using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Infrastructure.Data;

namespace EventManagementSystem.Infrastructure.Repository
{
    public class EventRepository : Repository<Event>, IEevntRepository
    {
        private readonly AppDbContext _db;

        public EventRepository(AppDbContext db) : base(db)         {
            _db = db;
        }

        public void Update(Event entity)
        {
            _db.Event.Update(entity);
        }

    }
}
