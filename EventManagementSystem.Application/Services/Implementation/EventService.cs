using EventManagementSystem.Application.Common.Interfaces;
using EventManagementSystem.Application.Services.Interface;
using EventManagementSystem.Application.Utility;
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

        public IEnumerable<Event> GetEventsAvailabilityByDate(int nights, DateTime checkInDate)
        {
            var eventList = _unitOfWork.Event.GetAll(includeProperties: "EventDetail").ToList();
            var villaNumbersList = _unitOfWork.EventNumber.GetAll().ToList();
            var bookedVillas = _unitOfWork.Booking.GetAll(u => u.Status == SD.StatusApproved ||
            u.Status == SD.StatusCheckedIn).ToList();


            foreach (var villa in eventList)
            {
                int roomAvailable = SD.VillaRoomsAvailable_Count
                    (villa.Id, villaNumbersList, checkInDate, nights, bookedVillas);

                villa.IsAvailable = roomAvailable > 0 ? true : false;
            }

            return eventList;
        }

        public bool IsEventAvailableByDate(int villaId, int nights, DateTime checkInDate)
        {
            var villaNumbersList = _unitOfWork.EventNumber.GetAll().ToList();
            var bookedVillas = _unitOfWork.Booking.GetAll(u => u.Status == SD.StatusApproved ||
            u.Status == SD.StatusCheckedIn).ToList();

            int roomAvailable = SD.VillaRoomsAvailable_Count
                (villaId, villaNumbersList, checkInDate, nights, bookedVillas);

            return roomAvailable > 0;
        }

        public void UpdateEvent(Event updateEvent)
        {
            _unitOfWork.Event.Update(updateEvent);
            _unitOfWork.Save();
        }
    }
}
