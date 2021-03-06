// <auto-generated />
using System;
using HotelApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220113225103_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelApp.Models.Custormers.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Requests")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("HotelApp.Models.Employees.Cleaner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Cleaners");
                });

            modelBuilder.Entity("HotelApp.Models.Hotels.Floor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildingFloor")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("HotelApp.Models.Hotels.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalRooms")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("HotelApp.Models.Hotels.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Booked")
                        .HasColumnType("bit");

                    b.Property<bool>("Cleaned")
                        .HasColumnType("bit");

                    b.Property<bool>("CleanerAssigned")
                        .HasColumnType("bit");

                    b.Property<int?>("CleanerId")
                        .HasColumnType("int");

                    b.Property<bool>("ClosedForCustomers")
                        .HasColumnType("bit");

                    b.Property<string>("ClosedReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FloorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CleanerId");

                    b.HasIndex("FloorId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HotelApp.Models.Location.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("HotelApp.Models.Location.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("HotelApp.Models.Employees.Cleaner", b =>
                {
                    b.HasOne("HotelApp.Models.Hotels.Hotel", "Hotel")
                        .WithMany("Cleaners")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelApp.Models.Hotels.Floor", b =>
                {
                    b.HasOne("HotelApp.Models.Hotels.Hotel", "Hotel")
                        .WithMany("Floors")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelApp.Models.Hotels.Hotel", b =>
                {
                    b.HasOne("HotelApp.Models.Location.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("HotelApp.Models.Hotels.Room", b =>
                {
                    b.HasOne("HotelApp.Models.Employees.Cleaner", "Cleaner")
                        .WithMany("RoomsAssigned")
                        .HasForeignKey("CleanerId");

                    b.HasOne("HotelApp.Models.Hotels.Floor", "Floor")
                        .WithMany("Rooms")
                        .HasForeignKey("FloorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cleaner");

                    b.Navigation("Floor");
                });

            modelBuilder.Entity("HotelApp.Models.Location.City", b =>
                {
                    b.HasOne("HotelApp.Models.Location.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("HotelApp.Models.Employees.Cleaner", b =>
                {
                    b.Navigation("RoomsAssigned");
                });

            modelBuilder.Entity("HotelApp.Models.Hotels.Floor", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HotelApp.Models.Hotels.Hotel", b =>
                {
                    b.Navigation("Cleaners");

                    b.Navigation("Floors");
                });

            modelBuilder.Entity("HotelApp.Models.Location.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
