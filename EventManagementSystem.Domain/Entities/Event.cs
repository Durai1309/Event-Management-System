﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagementSystem.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Range(10, 10000)]
        public double Price { get; set; }
        public int Sqft { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

        [Range(1, 10)]
        public int Occupancy { get; set; }
        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; }
        public DateTime? Created_Date { get; set; }
        public DateTime? Updated_Date { get; set; }

        [ValidateNever]
        public IEnumerable<EventDetail> EventDetail { get; set; }

        [NotMapped]
        public bool IsAvailable { get; set; } = true;
    }
}
