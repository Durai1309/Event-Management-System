using EventManagementSystem.Application.Common.Interfaces;
using EventManagementSystem.Application.Services.Interface;
using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Services.Implementation
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateEvent(Event createEvent)
        {
            _unitOfWork.Event.Add(createEvent);
            _unitOfWork.Save();
        }

        public bool DeleteEvent(int id)
        {
            try
            {
                Event? objFromDb = _unitOfWork.Event.Get(u => u.Id == id);
                if (objFromDb is not null)
                {
                    //if (!string.IsNullOrEmpty(objFromDb.ImageUrl))
                    //{
                    //    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, objFromDb.ImageUrl.TrimStart('\\'));

                    //    if (System.IO.File.Exists(oldImagePath))
                    //    {
                    //        System.IO.File.Delete(oldImagePath);
                    //    }
                    //}
                    _unitOfWork.Event.Remove(objFromDb);
                    _unitOfWork.Save();

                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Event> GetAllEvent()
        {
            return _unitOfWork.Event.GetAll(includeProperties: "EventDetail");
        }

        public Event GetEventById(int id)
        {
            return _unitOfWork.Event.Get(u => u.Id == id, includeProperties: "EventDetail");
        }

        public IEnumerable<Event> GetEventsAvailabilityByDate(int nights, DateOnly checkInDate)
        {
            throw new NotImplementedException();
        }

        public bool IsEventAvailableByDate(int villaId, int nights, DateOnly checkInDate)
        {
            throw new NotImplementedException();
        }

        public void UpdateEvent(Event updateEvent)
        {
            _unitOfWork.Event.Update(updateEvent);
            _unitOfWork.Save();
        }
    }
}
