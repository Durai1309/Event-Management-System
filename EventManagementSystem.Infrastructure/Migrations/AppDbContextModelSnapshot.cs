﻿// <auto-generated />
using System;
using EventManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventManagementSystem.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EventManagementSystem.Domain.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Created_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Event");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://placehold.co/600x400",
                            Name = "Royal Event",
                            Occupancy = 4,
                            Price = 200.0,
                            Sqft = 550
                        },
                        new
                        {
                            Id = 2,
                            Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://placehold.co/600x401",
                            Name = "Premium Pool Event",
                            Occupancy = 4,
                            Price = 300.0,
                            Sqft = 550
                        },
                        new
                        {
                            Id = 3,
                            Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://placehold.co/600x402",
                            Name = "Luxury Pool Event",
                            Occupancy = 4,
                            Price = 400.0,
                            Sqft = 750
                        });
                });

            modelBuilder.Entity("EventManagementSystem.Domain.Entities.EventNumber", b =>
                {
                    b.Property<int>("Event_Number")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("SpecialDetails")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Event_Number");

                    b.HasIndex("EventId");

                    b.ToTable("EventNumbers");

                    b.HasData(
                        new
                        {
                            Event_Number = 101,
                            EventId = 1
                        },
                        new
                        {
                            Event_Number = 102,
                            EventId = 1
                        },
                        new
                        {
                            Event_Number = 103,
                            EventId = 1
                        },
                        new
                        {
                            Event_Number = 104,
                            EventId = 1
                        },
                        new
                        {
                            Event_Number = 201,
                            EventId = 2
                        },
                        new
                        {
                            Event_Number = 202,
                            EventId = 2
                        },
                        new
                        {
                            Event_Number = 203,
                            EventId = 2
                        },
                        new
                        {
                            Event_Number = 301,
                            EventId = 3
                        },
                        new
                        {
                            Event_Number = 302,
                            EventId = 3
                        });
                });

            modelBuilder.Entity("EventManagementSystem.Domain.Entities.EventNumber", b =>
                {
                    b.HasOne("EventManagementSystem.Domain.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });
#pragma warning restore 612, 618
        }
    }
}
