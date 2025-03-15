using EventManagementSystem.Application.Services.Interface;
using EventManagementSystem.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IEventService eventService, IWebHostEnvironment webHostEnvironment)
        {
            _eventService = eventService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                EventList = _eventService.GetAllEvent(),
                Nights = 1,
                CheckInDate = DateOnly.FromDateTime(DateTime.Now),
            };
            return View(homeVM);
        }

        [HttpPost]
        public IActionResult GetEventByDate(int nights, DateOnly checkInDate)
        {

            HomeVM homeVM = new()
            {
                CheckInDate = checkInDate,
                EventList = _eventService.GetEventsAvailabilityByDate(nights, checkInDate),
                Nights = nights
            };

            return PartialView("_EventList", homeVM);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
