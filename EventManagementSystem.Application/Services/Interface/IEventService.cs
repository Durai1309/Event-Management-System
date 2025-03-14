using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Services.Interface
{
    public interface IEventService
    {
        IEnumerable<Event> GetAllEvent();
        Event GetEventById(int id);
        void CreateEvent(Event createEvent);
        void UpdateEvent(Event updateEvent);
        bool DeleteEvent(int id);
        IEnumerable<Event> GetEventsAvailabilityByDate(int nights, DateOnly checkInDate);
        bool IsEventAvailableByDate(int villaId, int nights, DateOnly checkInDate);
    }
}
