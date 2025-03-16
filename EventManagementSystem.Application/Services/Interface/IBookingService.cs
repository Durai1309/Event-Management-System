using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Services.Interface
{
    public interface IBookingService
    {

        void CreateBooking(Booking booking);
        Booking GetBookingById(int bookingId);
        IEnumerable<Booking> GetAllBookings(string userId = "", string? statusFilterList = "");

        void UpdateStatus(int bookingId, string bookingStatus, int eventNumber);
        public IEnumerable<int> GetCheckedInVillaNumbers(int eventId);
    }
}
