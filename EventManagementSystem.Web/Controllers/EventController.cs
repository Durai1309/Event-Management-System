using EventManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Web.Controllers
{
    public class EventController : Controller
    {
        public EventController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
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
            if (ModelState.IsValid)
            {

                _villaService.CreateVilla(obj);
                TempData["success"] = "The Event has been created successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Update(int eventId)
        {
            Event? obj = _villaService.GetVillaById(eventId);
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

                _villaService.UpdateVilla(obj);
                TempData["success"] = "The Event has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int eventId)
        {
            Event? obj = _villaService.GetVillaById(eventId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }


        [HttpPost]
        public IActionResult Delete(Event obj)
        {
            bool deleted = _villaService.DeleteVilla(obj.Id);
            if (deleted)
            {
                TempData["success"] = "The villa has been deleted successfully.";
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
