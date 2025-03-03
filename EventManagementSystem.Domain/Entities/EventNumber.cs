using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EventManagementSystem.Domain.Entities
{
    public class EventNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Event Number")]
        public int Event_Number { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        [ValidateNever]
        public Event Event { get; set; }
        public string? SpecialDetails { get; set; }
    }
}
