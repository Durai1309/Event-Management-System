using EventManagementSystem.Application.Common.Interfaces;
using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Infrastructure.Data;

namespace EventManagementSystem.Infrastructure.Repository
{
    public class EventDetailRepository : Repository<EventDetail>, IEventDetailRepository
    {
        private readonly AppDbContext _db;

        public EventDetailRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(EventDetail entity)
        {
            _db.EventDetailS.Update(entity);
        }
    }
}
