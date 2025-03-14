//using EventManagementSystem.Domain.Entities;
//using EventManagementSystem.Web.ViewModels;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace EventManagementSystem.Web.Controllers
//{
//    public class EventDetailController : Controller
//    {
//        private readonly IAmenityService _amenityService;
//        private readonly IVillaService _villaService;

//        public EventDetailController(IAmenityService amenityService, IVillaService villaService)
//        {
//            _amenityService = amenityService;
//            _villaService = villaService;
//        }

//        public IActionResult Index()
//        {
//            var amenities = _amenityService.GetAllAmenities();
//            return View(amenities);
//        }

//        public IActionResult Create()
//        {
//            EventDetailVM EventDetailVM = new()
//            {
//                EventDetailList = _villaService.GetAllVillas().Select(u => new SelectListItem
//                {
//                    Text = u.Name,
//                    Value = u.Id.ToString()
//                })
//            };
//            return View(EventDetailVM);
//        }

//        [HttpPost]
//        public IActionResult Create(EventDetailVM obj)
//        {

//            if (ModelState.IsValid)
//            {
//                _amenityService.CreateAmenity(obj.EventDetail);
//                TempData["success"] = "The amenity has been created successfully.";
//                return RedirectToAction(nameof(Index));
//            }

//            obj.EventDetailList = _villaService.GetAllVillas().Select(u => new SelectListItem
//            {
//                Text = u.Name,
//                Value = u.Id.ToString()
//            });
//            return View(obj);
//        }

//        public IActionResult Update(int amenityId)
//        {
//            EventDetailVM EventDetailVM = new()
//            {
//                EventDetailList = _villaService.GetAllVillas().Select(u => new SelectListItem
//                {
//                    Text = u.Name,
//                    Value = u.Id.ToString()
//                }),
//                EventDetail = _amenityService.GetAmenityById(amenityId)
//            };
//            if (EventDetailVM.EventDetail == null)
//            {
//                return RedirectToAction("Error", "Home");
//            }
//            return View(EventDetailVM);
//        }


//        [HttpPost]
//        public IActionResult Update(EventDetailVM EventDetailVM)
//        {

//            if (ModelState.IsValid)
//            {
//                _amenityService.UpdateAmenity(EventDetailVM.EventDetail);
//                TempData["success"] = "The amenity has been updated successfully.";
//                return RedirectToAction(nameof(Index));
//            }

//            EventDetailVM.EventDetailList = _villaService.GetAllVillas().Select(u => new SelectListItem
//            {
//                Text = u.Name,
//                Value = u.Id.ToString()
//            });
//            return View(EventDetailVM);
//        }



//        public IActionResult Delete(int Id)
//        {
//            EventDetailVM EventDetailVM = new()
//            {
//                EventDetailList = _villaService.GetAllVillas().Select(u => new SelectListItem
//                {
//                    Text = u.Name,
//                    Value = u.Id.ToString()
//                }),
//                EventDetail = _amenityService.GetAmenityById(Id)
//            };
//            if (EventDetailVM.EventDetail == null)
//            {
//                return RedirectToAction("Error", "Home");
//            }
//            return View(EventDetailVM);
//        }



//        [HttpPost]
//        public IActionResult Delete(EventDetailVM EventDetailVM)
//        {
//            EventDetail? objFromDb = _amenityService.GetAmenityById(EventDetailVM.EventDetail.Id);
//            if (objFromDb is not null)
//            {
//                _amenityService.DeleteAmenity(objFromDb.Id);
//                TempData["success"] = "The amenity has been deleted successfully.";
//                return RedirectToAction(nameof(Index));
//            }
//            TempData["error"] = "The amenity could not be deleted.";
//            return View();
//        }
//    }
//}
