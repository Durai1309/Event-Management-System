using EventManagementSystem.Domain.Entities;

namespace EventManagementSystem.Web.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Event>? EventList { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int Nights { get; set; }

    }
}
