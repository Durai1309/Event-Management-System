using EventManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //3.43
        }
        public DbSet<Event> Event { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Name = "Royal Event",
                    Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    ImageUrl = "https://placehold.co/600x400",
                    Occupancy = 4,
                    Price = 200,
                    Sqft = 550,
                },
                    new Event
                    {
                        Id = 2,
                        Name = "Premium Pool Event",
                        Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                        ImageUrl = "https://placehold.co/600x401",
                        Occupancy = 4,
                        Price = 300,
                        Sqft = 550,
                    },
                    new Event
                    {
                        Id = 3,
                        Name = "Luxury Pool Event",
                        Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                        ImageUrl = "https://placehold.co/600x402",
                        Occupancy = 4,
                        Price = 400,
                        Sqft = 750,
                    });

            //    modelBuilder.Entity<EventNumber>().HasData(
            //        new EventNumber
            //        {
            //            Event_Number = 101,
            //            EventId = 1,
            //        },
            //        new EventNumber
            //        {
            //            Event_Number = 102,
            //            EventId = 1,
            //        },
            //        new EventNumber
            //        {
            //            Event_Number = 103,
            //            EventId = 1,
            //        },
            //        new EventNumber
            //        {
            //            Event_Number = 104,
            //            EventId = 1,
            //        },
            //        new EventNumber
            //        {
            //            Event_Number = 201,
            //            EventId = 2,
            //        },
            //        new EventNumber
            //        {
            //            Event_Number = 202,
            //            EventId = 2,
            //        },
            //        new EventNumber
            //        {
            //            Event_Number = 203,
            //            EventId = 2,
            //        },
            //        new EventNumber
            //        {
            //            Event_Number = 301,
            //            EventId = 3,
            //        },
            //        new EventNumber
            //        {
            //            Event_Number = 302,
            //            EventId = 3,
            //        }
            //        );

            //    modelBuilder.Entity<EventDetail>().HasData(
            //  new EventDetail
            //  {
            //      Id = 1,
            //      EventId = 1,
            //      Name = "Private Pool"
            //  }, new EventDetail
            //  {
            //      Id = 2,
            //      EventId = 1,
            //      Name = "Microwave"
            //  }, new EventDetail
            //  {
            //      Id = 3,
            //      EventId = 1,
            //      Name = "Private Balcony"
            //  }, new EventDetail
            //  {
            //      Id = 4,
            //      EventId = 1,
            //      Name = "1 king bed and 1 sofa bed"
            //  },

            //  new EventDetail
            //  {
            //      Id = 5,
            //      EventId = 2,
            //      Name = "Private Plunge Pool"
            //  }, new EventDetail
            //  {
            //      Id = 6,
            //      EventId = 2,
            //      Name = "Microwave and Mini Refrigerator"
            //  }, new EventDetail
            //  {
            //      Id = 7,
            //      EventId = 2,
            //      Name = "Private Balcony"
            //  }, new EventDetail
            //  {
            //      Id = 8,
            //      EventId = 2,
            //      Name = "king bed or 2 double beds"
            //  },

            //  new EventDetail
            //  {
            //      Id = 9,
            //      EventId = 3,
            //      Name = "Private Pool"
            //  }, new EventDetail
            //  {
            //      Id = 10,
            //      EventId = 3,
            //      Name = "Jacuzzi"
            //  }, new EventDetail
            //  {
            //      Id = 11,
            //      EventId = 3,
            //      Name = "Private Balcony"
            //  });

            //}
        }
    }
}