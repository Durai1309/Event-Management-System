using EventManagementSystem.Domain.Entities;

namespace EventManagementSystem.Application.Services.Interface
{
    public interface IEventNumberService
    {
        IEnumerable<EventNumber> GetAllEventNumbers();
        EventNumber GetEventNumberById(int id);
        void CreateEventNumber(EventNumber eventNumber);
        void UpdateEventNumber(EventNumber eventNumber);
        bool DeleteEventNumber(int id);
        bool CheckEventNumberExists(int event_Number);
    }
}
