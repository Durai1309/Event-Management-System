namespace EventManagementSystem.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IEevntRepository Event { get; }

    }
}
