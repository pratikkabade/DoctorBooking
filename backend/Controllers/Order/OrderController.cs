using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private DataBaseContext order_context;
        public OrderController(DataBaseContext order_context)
        {
            this.order_context = order_context;
        }

        // CREATE
        [HttpPost]
        public string Post([FromBody] Order transaction)
        {
            this.order_context.Orders.Add(transaction);
            this.order_context.SaveChanges();
            return "Order sent successfully!";
        }


        // GET ORDERS
        [Authorize(Roles = "Admin")]
        [HttpGet("order")]
        public IEnumerable<UserOrder> GetOrder()
        {
            var usersOrder = from o in order_context.Set<Order>()
                             join u in order_context.Set<Users>()
                             on o.UserId equals u.UserId
                             select new UserOrder
                             {
                                 TransactionId = o.TransactionId,

                                 MemberId = o.MemberId,
                                 Insurance_Policy_Number = o.Insurance_Policy_Number,
                                 InsuranceProvider = o.InsuranceProvider,
                                 PrescriptionDate = o.PrescriptionDate,
                                 DosageForDay = o.DosageForDay,
                                 PrescriptionCourse = o.PrescriptionCourse,
                                 DoctorDetails = o.DoctorDetails,

                                 UserId = o.UserId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                             };
            return usersOrder.ToList();
        }

        [HttpGet("order/{id}")]
        public IEnumerable<UserOrder> GetOrderById()
        {
            var usersOrder = from o in order_context.Set<Order>()
                             join u in order_context.Set<Users>()
                             on o.UserId equals u.UserId
                             select new UserOrder
                             {
                                 TransactionId = o.TransactionId,

                                 MemberId = o.MemberId,
                                 Insurance_Policy_Number = o.Insurance_Policy_Number,
                                 InsuranceProvider = o.InsuranceProvider,
                                 PrescriptionDate = o.PrescriptionDate,
                                 DosageForDay = o.DosageForDay,
                                 PrescriptionCourse = o.PrescriptionCourse,
                                 DoctorDetails = o.DoctorDetails,

                                 UserId = o.UserId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                             };
            return usersOrder.ToList();
        }




        // GET DRUGS
        [Authorize(Roles = "Admin")]
        [HttpGet("drug")]
        public IEnumerable<UserDrug> GetDrug()
        {
            var usersDrug = from u in order_context.Set<Users>()
                            join d in order_context.Set<Drugs>()
                            on u.UserId equals d.UserId
                            select new UserDrug
                            {
                                DrugId = d.DrugId,
                                Name = d.Name,
                                Manufacturer = d.Manufacturer,
                                ManufacturedDate = d.ManufacturedDate,
                                ExpiryDate = d.ExpiryDate,
                                Quantities = d.Quantities,
                                Location = d.Location,

                                UserId = u.UserId,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Email = u.Email,
                            };
            return usersDrug.ToList();
        }
    }
}
