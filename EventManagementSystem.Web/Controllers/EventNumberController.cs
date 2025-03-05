using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventManagementSystem.Web.Controllers
{
    public class EventNumberController : Controller
    {

        public EventNumberController()
        {
            
        }
        public IActionResult Index()
        {
            var EventNumbers = _villaNumberService.GetAllVillaNumbers();
            return View(EventNumbers);
        }

        public IActionResult Create()
        {
            EventNumberVM villaNumberVM = new()
            {
                EventList = _villaService.GetAllVillas().Select(u => new SelectListItem
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
            //ModelState.Remove("Villa");

            bool roomNumberExists = _villaNumberService.CheckVillaNumberExists(obj.EventNumber.Event_Number);

            if (ModelState.IsValid && !roomNumberExists)
            {
                _villaNumberService.CreateVillaNumber(obj.EventNumber);
                TempData["success"] = "The villa Number has been created successfully.";
                return RedirectToAction(nameof(Index));
            }

            if (roomNumberExists)
            {
                TempData["error"] = "The villa Number already exists.";
            }
            obj.EventList = _villaService.GetAllVillas().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(obj);
        }

        public IActionResult Update(int villaNumberId)
        {
            EventNumberVM villaNumberVM = new()
            {
                EventList = _villaService.GetAllVillas().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                EventNumber = _villaNumberService.GetVillaNumberById(villaNumberId)
            };
            if (villaNumberVM.EventNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaNumberVM);
        }


        [HttpPost]
        public IActionResult Update(EventNumberVM eventNumberVM)
        {

            if (ModelState.IsValid)
            {
                _villaNumberService.UpdateVillaNumber(eventNumberVM.EventNumber);
                TempData["success"] = "The villa Number has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            eventNumberVM.EventList = _villaService.GetAllVillas().Select(u => new SelectListItem
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
                EventList = _villaService.GetAllVillas().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                EventNumber = _villaNumberService.GetVillaNumberById(eventNumberId)
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
            EventNumber? objFromDb = _villaNumberService.GetVillaNumberById(eventNumberVM.EventNumber.Event_Number);
            if (objFromDb is not null)
            {
                _villaNumberService.DeleteVillaNumber(objFromDb.Event_Number);
                TempData["success"] = "The villa number has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The villa number could not be deleted.";
            return View();
        }
    }
}
