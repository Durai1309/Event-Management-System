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
    }
}
