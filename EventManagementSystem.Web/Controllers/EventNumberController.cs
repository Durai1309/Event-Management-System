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
            return View();
        }

        public IActionResult Create()
        {
            EventNumberVM villaNumberVM = new()
            {
                VillaList = _villaService.GetAllVillas().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            return View(villaNumberVM);
        }
    }
}
