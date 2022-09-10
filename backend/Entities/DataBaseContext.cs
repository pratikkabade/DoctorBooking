using System;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<Users> User { get; set; }
        public DbSet<ContactUs> ContactMsg { get; set; }
        public DbSet<Drugs> Drug { get; set; }
        public DbSet<Order> Orders { get; set; }

        // GIVING PREDIFINED DATA TO DATABASE 
        // CREATING ADMIN USER
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    UserId = 1,
                    Email = "admin@gmail.com",
                    Password = "Passcode1",
                    Role = Roles.Admin
                }
                );
            modelBuilder.Entity<ContactUs>().HasData(
                new ContactUs
                {
                    Id = 1,
                    Date = DateTime.Now,
                    Name = "sample",
                    Email = "sample@gmail.com",
                    Message = "Hello, I am sample user. I am facing some issues with the website. Please help me out."
                });

            // modelBuilder.Entity<Drugs>().HasData(
            //     new Drugs
            //     {
            //         // DrugId = 1,
            //         Name = "Sinarest",
            //         Manufacturer = "Adv Pharma",
            //         // ManufacturedDate = "2022-11-11T11:32:22",
            //         // ExpiryDate = "2022-11-01T00:00:00",
            //         Quantities = 250,
            //         Location = "pune"
            //     }
            //     );
            // modelBuilder.Entity<Order>().HasData(
            //     new Order
            //     {
            //         TransactionId = 1,
            //         MemberId = 1,
            //         Insurance_Policy_Number = 123456789,
            //         InsuranceProvider = "ICICI",
            //         PrescriptionDate = DateTime.Now,
            //         DosageForDay = 2,
            //         PrescriptionCourse = "2 weeks",
            //         DoctorDetails = "Dr. John",
            //         UserId = 1,
            //         // DrugId = 1
            //     });
        }
    }
}
