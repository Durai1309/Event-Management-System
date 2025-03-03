using EventManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventManagementSystem.Web.ViewModels
{
    public class EventNumberVM
    {
        public EventNumber? EventNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? EventList { get; set; }
    }
}
