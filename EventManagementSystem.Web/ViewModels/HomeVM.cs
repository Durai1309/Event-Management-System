using EventManagementSystem.Domain.Entities;

namespace EventManagementSystem.Web.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Event>? EventList { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly? CheckOutDate { get; set; }
        public int Nights { get; set; }
    }
}
