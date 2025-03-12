using EventManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventManagementSystem.Web.ViewModels
{
    public class EventDetailVM
    {
        public EventDetail? EventDetail { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? EventDetailList { get; set; }
    }
}
