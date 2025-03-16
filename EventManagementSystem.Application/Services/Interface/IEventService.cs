using EventManagementSystem.Domain.Entities;

namespace EventManagementSystem.Application.Services.Interface
{
    public interface IEventService
    {
        IEnumerable<Event> GetAllEvent();
        Event GetEventById(int id);
        void CreateEvent(Event createEvent);
        void UpdateEvent(Event updateEvent);
        bool DeleteEvent(int id);
        IEnumerable<Event> GetEventsAvailabilityByDate(int nights, DateTime checkInDate);
        bool IsEventAvailableByDate(int villaId, int nights, DateTime checkInDate);
    }
}
