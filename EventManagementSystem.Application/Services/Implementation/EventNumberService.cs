using EventManagementSystem.Application.Common.Interfaces;
using EventManagementSystem.Application.Services.Interface;
using EventManagementSystem.Domain.Entities;

namespace EventManagementSystem.Application.Services.Implementation
{
    public class EventNumberService : IEventNumberService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventNumberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CheckEventNumberExists(int event_Number)
        {
            return _unitOfWork.EventNumber.Any(u => u.Event_Number == event_Number);
        }

        public void CreateEventNumber(EventNumber eventNumber)
        {
            _unitOfWork.EventNumber.Add(eventNumber);
            _unitOfWork.Save();
        }

        public bool DeleteEventNumber(int id)
        {
            try
            {
                EventNumber? objFromDb = _unitOfWork.EventNumber.Get(u => u.Event_Number == id);
                if (objFromDb is not null)
                {
                    _unitOfWork.EventNumber.Remove(objFromDb);
                    _unitOfWork.Save();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<EventNumber> GetAllEventNumbers()
        {
            return _unitOfWork.EventNumber.GetAll(includeProperties: "Event");
        }

        public EventNumber GetEventNumberById(int id)
        {
            return _unitOfWork.EventNumber.Get(u => u.Event_Number == id, includeProperties: "Event");
        }

        public void UpdateEventNumber(EventNumber eventNumber)
        {
            _unitOfWork.EventNumber.Update(eventNumber);
            _unitOfWork.Save();
        }
    }
}
