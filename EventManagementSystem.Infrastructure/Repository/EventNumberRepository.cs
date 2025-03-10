using EventManagementSystem.Application.Common.Interfaces;
using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Infrastructure.Repository
{
    internal class EventNumberRepository : Repository<EventNumber>, IEventNumberRepository
    {

        private readonly AppDbContext _db;

        public EventNumberRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(EventNumber entity)
        {
            _db.EventNumbers.Update(entity);
        }
    }
}
