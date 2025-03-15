using EventManagementSystem.Application.Services.Interface;
using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventManagementSystem.Web.Controllers
{
    public class EventNumberController : Controller
    {

        private readonly IEventNumberService _eventNumberService;
        private readonly IEventService _eventService;
        public EventNumberController(IEventNumberService eventNumberService, IEventService eventService)
        {
            _eventService = eventService;
            _eventNumberService = eventNumberService;
        }
        public IActionResult Index()
        {
            var EventNumbers = _eventNumberService.GetAllEventNumbers();
            return View(EventNumbers);
        }

        public IActionResult Create()
        {
            EventNumberVM villaNumberVM = new()
            {
                EventList = _eventService.GetAllEvent().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Create(EventNumberVM obj)
        {
            bool roomNumberExists = _eventNumberService.CheckEventNumberExists(obj.EventNumber.Event_Number);

            if (ModelState.IsValid && !roomNumberExists)
            {
                _eventNumberService.CreateEventNumber(obj.EventNumber);
                TempData["success"] = "The Event Number has been created successfully.";
                return RedirectToAction(nameof(Index));
            }

            if (roomNumberExists)
            {
                TempData["error"] = "The Event Number already exists.";
            }
            obj.EventList = _eventService.GetAllEvent().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(obj);
        }

        public IActionResult Update(int EventNumberId)
        {
            EventNumberVM eventaNumberVM = new()
            {
                EventList = _eventService.GetAllEvent().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                EventNumber = _eventNumberService.GetEventNumberById(EventNumberId)
            };
            if (eventaNumberVM.EventNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(eventaNumberVM);
        }


        [HttpPost]
        public IActionResult Update(EventNumberVM eventNumberVM)
        {

            if (ModelState.IsValid)
            {
                _eventNumberService.UpdateEventNumber(eventNumberVM.EventNumber);
                TempData["success"] = "The Event Number has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            eventNumberVM.EventList = _eventService.GetAllEvent().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(eventNumberVM);
        }



        public IActionResult Delete(int eventNumberId)
        {
            EventNumberVM eventNumberVM = new()
            {
                EventList = _eventService.GetAllEvent().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                EventNumber = _eventNumberService.GetEventNumberById(eventNumberId)
            };
            if (eventNumberVM.EventNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(eventNumberVM);
        }



        [HttpPost]
        public IActionResult Delete(EventNumberVM eventNumberVM)
        {
            EventNumber? objFromDb = _eventNumberService.GetEventNumberById(eventNumberVM.EventNumber.Event_Number);
            if (objFromDb is not null)
            {
                _eventNumberService.DeleteEventNumber(objFromDb.Event_Number);
                TempData["success"] = "The Event number has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The Event number could not be deleted.";
            return View();
        }
    }
}
