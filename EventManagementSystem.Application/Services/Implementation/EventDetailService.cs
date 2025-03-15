using EventManagementSystem.Application.Common.Interfaces;
using EventManagementSystem.Application.Services.Interface;
using EventManagementSystem.Domain.Entities;

namespace EventManagementSystem.Application.Services.Implementation
{
    public class EventDetailService : IEventDetailService
    {

        private readonly IUnitOfWork _unitOfWork;
        public EventDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateEventDetail(EventDetail eventDetail)
        {
            ArgumentNullException.ThrowIfNull(eventDetail);

            _unitOfWork.EventDetail.Add(eventDetail);
            _unitOfWork.Save();
        }

        public bool DeleteEventDetail(int id)
        {
            try
            {
                var eventDetail = _unitOfWork.EventDetail.Get(u => u.Id == id);

                if (eventDetail != null)
                {

                    _unitOfWork.EventDetail.Remove(eventDetail);
                    _unitOfWork.Save();
                    return true;
                }
                else
                {
                    throw new InvalidOperationException($"EventDetail with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public IEnumerable<EventDetail> GetAllEventDetail()
        {
            return _unitOfWork.EventDetail.GetAll(includeProperties: "Event");
        }

        public EventDetail GetEventDetailById(int id)
        {
            return _unitOfWork.EventDetail.Get(u => u.Id == id, includeProperties: "Event");
        }

        public void UpdateEventDetail(EventDetail eventDetail)
        {
            ArgumentNullException.ThrowIfNull(eventDetail);

            _unitOfWork.EventDetail.Update(eventDetail);
            _unitOfWork.Save();
        }
    }
}
