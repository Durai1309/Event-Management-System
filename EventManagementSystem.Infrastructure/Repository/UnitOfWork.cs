﻿using EventManagementSystem.Application.Common.Interfaces;
using EventManagementSystem.Infrastructure.Data;

namespace EventManagementSystem.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public IEevntRepository Event { get; private set; }
        public IEventNumberRepository EventNumber { get; private set; }
        public IEventDetailRepository EventDetail { get; private set; }
        public IApplicationUserRepository User { get; private set; }
        public IBookingRepository Booking { get; private set; }



        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Event = new EventRepository(_db);
            EventNumber = new EventNumberRepository(_db);
            EventDetail = new EventDetailRepository(_db);
            User = new ApplicationUserRepository(_db);
            Booking = new BookingRepository(_db);

        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}