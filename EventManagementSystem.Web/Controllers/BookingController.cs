using EventManagementSystem.Application.Services.Implementation;
using EventManagementSystem.Application.Services.Interface;
using EventManagementSystem.Application.Utility;
using EventManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventManagementSystem.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEventService _eventService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEventNumberService _eventNumberService;
        public BookingController(IBookingService bookingService,
            IEventService eventService, IEventNumberService eventNumberService,
            IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _eventService = eventService;
            _eventNumberService = eventNumberService;
            _bookingService = bookingService;
            _webHostEnvironment = webHostEnvironment;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult FinalizeBooking(int eventId, DateTime checkInDate, int nights)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ApplicationUser user = _userManager.FindByIdAsync(userId).GetAwaiter().GetResult();

            Booking booking = new()
            {
                EventId = eventId,
                Event = _eventService.GetEventById(eventId),
                CheckInDate = checkInDate,
                Nights = nights,
                CheckOutDate = checkInDate.AddDays(nights),
                UserId = userId,
                Phone = user.PhoneNumber,
                Email = user.Email,
                Name = user.Name
            };
            booking.TotalCost = booking.Event.Price * nights;
            return View(booking);
        }

        [Authorize]
        [HttpPost]
        public IActionResult FinalizeBooking(Booking booking)
        {
            var events = _eventService.GetEventById(booking.EventId);
            booking.TotalCost = events.Price * booking.Nights;

            booking.Status = SD.StatusPending;
            booking.BookingDate = DateTime.Now;
            if (!_eventService.IsEventAvailableByDate(events.Id, booking.Nights, booking.CheckInDate))
            {
                TempData["error"] = "Room has been sold out!";
                return RedirectToAction(nameof(FinalizeBooking), new
                {
                    villaId = booking.EventId,
                    checkInDate = booking.CheckInDate,
                    nights = booking.Nights
                });
            }

            _bookingService.CreateBooking(booking);
            return new StatusCodeResult(303);
        }

        [Authorize]
        public IActionResult BookingConfirmation(int bookingId)
        {
            Booking bookingFromDb = _bookingService.GetBookingById(bookingId);

            if (bookingFromDb.Status == SD.StatusPending)
            {
                //this is a pending order, we need to confirm if payment was successful

                if (bookingFromDb.Status == "paid")
                {
                    _bookingService.UpdateStatus(bookingFromDb.Id, SD.StatusApproved, 0);
                }
            }

            return View(bookingId);
        }

        [Authorize]
        public IActionResult BookingDetails(int bookingId)
        {
            Booking bookingFromDb = _bookingService.GetBookingById(bookingId);

            if (bookingFromDb.EventNumber == 0 && bookingFromDb.Status == SD.StatusApproved)
            {
                var availableVillaNumber = AssignAvailableVillaNumberByVilla(bookingFromDb.EventId);

                var eventNumber = _eventNumberService.GetAllEventNumbers()
                .FirstOrDefault(u => u.EventId == bookingFromDb.EventId
                           && availableVillaNumber.Contains(u.Event_Number));

                if (eventNumber != null)
                {
                    bookingFromDb.EventNumber = eventNumber.Event_Number;
                }
                else
                {
                    bookingFromDb.EventNumber = 0;
                }
            }

            return View(bookingFromDb);
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult CheckIn(Booking booking)
        {
            _bookingService.UpdateStatus(booking.Id, SD.StatusCheckedIn, booking.EventNumber);
            TempData["Success"] = "Booking Updated Successfully.";
            return RedirectToAction(nameof(BookingDetails), new { bookingId = booking.Id });
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult CheckOut(Booking booking)
        {
            _bookingService.UpdateStatus(booking.Id, SD.StatusCompleted, booking.EventNumber);
            TempData["Success"] = "Booking Completed Successfully.";
            return RedirectToAction(nameof(BookingDetails), new { bookingId = booking.Id });
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult CancelBooking(Booking booking)
        {
            _bookingService.UpdateStatus(booking.Id, SD.StatusCancelled, 0);
            TempData["Success"] = "Booking Cancelled Successfully.";
            return RedirectToAction(nameof(BookingDetails), new { bookingId = booking.Id });
        }


        private List<int> AssignAvailableVillaNumberByVilla(int villaId)
        {
            List<int> availableVillaNumbers = new();

            var villaNumbers = _eventNumberService.GetAllEventNumbers().Where(u => u.EventId == villaId);

            var checkedInVilla = _bookingService.GetCheckedInVillaNumbers(villaId);

            foreach (var villaNumber in villaNumbers)
            {
                if (!checkedInVilla.Contains(villaNumber.Event_Number))
                {
                    availableVillaNumbers.Add(villaNumber.Event_Number);
                }
            }
            return availableVillaNumbers;
        }


        [HttpGet]
        [Authorize]
        public IActionResult GetAll(string status)
        {
            IEnumerable<Booking> objBookings;
            string userId = "";
            if (string.IsNullOrEmpty(status))
            {
                status = "";
            }

            if (!User.IsInRole(SD.Role_Admin))
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            }

            objBookings = _bookingService.GetAllBookings(userId, status);

            return Json(new { data = objBookings });
        }

    }
}
