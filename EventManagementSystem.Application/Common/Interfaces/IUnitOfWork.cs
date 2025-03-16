namespace EventManagementSystem.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IEevntRepository Event { get; }

        IEventNumberRepository EventNumber { get; }

        IEventDetailRepository EventDetail { get; }

        IApplicationUserRepository User { get; }

        IBookingRepository Booking { get; }

        void Save();
    }
}
