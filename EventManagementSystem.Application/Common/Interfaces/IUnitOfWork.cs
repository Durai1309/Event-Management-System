namespace EventManagementSystem.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IEevntRepository Event { get; }

        IEventNumberRepository EventNumber { get; }

        IEventDetailRepository EventDetail { get; }

        void Save();
    }
}
