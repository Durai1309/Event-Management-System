using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Services.Interface
{
    public interface IEventDetailService
    {
        IEnumerable<EventDetail> GetAllEventDetail();
        void CreateEventDetail(EventDetail eventDetail);
        void UpdateEventDetail(EventDetail eventDetail);
        EventDetail GetEventDetailById(int id);
        bool DeleteEventDetail(int id);
    }
}
