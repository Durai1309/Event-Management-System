using EventManagementSystem.Application.Services.Interface;
using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventManagementSystem.Web.Controllers
{
    public class EventDetailController : Controller
    {
        private readonly IEventDetailService _eventDetailService;
        private readonly IEventService _eventService;

        public EventDetailController(IEventDetailService eventDetailService, IEventService eventService)
        {
            _eventDetailService = eventDetailService;
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            var amenities = _eventDetailService.GetAllEventDetail();
            return View(amenities);
        }

        public IActionResult Create()
        {
            EventDetailVM EventDetailVM = new()
            {
                EventDetailList = _eventService.GetAllEvent().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            return View(EventDetailVM);
        }

        [HttpPost]
        public IActionResult Create(EventDetailVM obj)
        {

            if (ModelState.IsValid)
            {
                _eventDetailService.CreateEventDetail(obj.EventDetail);
                TempData["success"] = "The EventDetail has been created successfully.";
                return RedirectToAction(nameof(Index));
            }

            obj.EventDetailList = _eventService.GetAllEvent().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(obj);
        }

        public IActionResult Update(int eventId)
        {
            EventDetailVM EventDetailVM = new()
            {
                EventDetailList = _eventService.GetAllEvent().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                EventDetail = _eventDetailService.GetEventDetailById(eventId)
            };
            if (EventDetailVM.EventDetail == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(EventDetailVM);
        }


        [HttpPost]
        public IActionResult Update(EventDetailVM EventDetailVM)
        {

            if (ModelState.IsValid)
            {
                _eventDetailService.UpdateEventDetail(EventDetailVM.EventDetail);
                TempData["success"] = "The EventDetail has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            EventDetailVM.EventDetailList = _eventService.GetAllEvent().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(EventDetailVM);
        }



        public IActionResult Delete(int eventId)
        {
            EventDetailVM EventDetailVM = new()
            {
                EventDetailList = _eventService.GetAllEvent().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                EventDetail = _eventDetailService.GetEventDetailById(eventId)
            };
            if (EventDetailVM.EventDetail == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(EventDetailVM);
        }



        [HttpPost]
        public IActionResult Delete(EventDetailVM EventDetailVM)
        {
            EventDetail? objFromDb = _eventDetailService.GetEventDetailById(EventDetailVM.EventDetail.Id);
            if (objFromDb is not null)
            {
                _eventDetailService.DeleteEventDetail(objFromDb.Id);
                TempData["success"] = "The EventDetail has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The EventDetail could not be deleted.";
            return View();
        }
    }
}
