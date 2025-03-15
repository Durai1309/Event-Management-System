using EventManagementSystem.Application.Services.Implementation;
using EventManagementSystem.Application.Services.Interface;
using EventManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        private readonly IWebHostEnvironment _webHostEnvironment;
        public EventController(IEventService eventService, IWebHostEnvironment webHostEnvironment)
        {
            _eventService = eventService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var events = _eventService.GetAllEvent();
            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("name", "The description cannot exactly match the Name.");
            }

            if (obj.Image != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\EventImage");

                if (!Directory.Exists(imagePath))
                {
                    Directory.CreateDirectory(imagePath);
                }

                using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                obj.Image.CopyTo(fileStream);

                obj.ImageUrl = @"\images\EventImage\" + fileName;
            }
            else
            {
                obj.ImageUrl = "https://placehold.co/600x400";
            }
            if (ModelState.IsValid)
            {
                _eventService.CreateEvent(obj);
                TempData["success"] = "The Event has been created successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        public IActionResult Update(int eventId)
        {
            Event? obj = _eventService.GetEventById(eventId);
            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(Event obj)
        {
            if (ModelState.IsValid && obj.Id > 0)
            {
                if (obj.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\EventImage");

                    if (!string.IsNullOrEmpty(obj.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                    obj.Image.CopyTo(fileStream);

                    obj.ImageUrl = @"\images\EventImage\" + fileName;
                }
                _eventService.UpdateEvent(obj);
                TempData["success"] = "The Event has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int eventId)
        {
            Event? obj = _eventService.GetEventById(eventId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }


        [HttpPost]
        public IActionResult Delete(Event obj)
        {
            bool deleted = _eventService.DeleteEvent(obj.Id);
            if (deleted)
            {
                TempData["success"] = "The Event has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = "Failed to delete the villa.";
            }
            return View();
        }

    }
}
