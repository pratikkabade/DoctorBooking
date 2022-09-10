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
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MedicineController : Controller
    {
        private DataBaseContext med_context;
        public MedicineController(DataBaseContext med_context)
        {
            this.med_context = med_context;
        }

        // INDEX
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IEnumerable<Medicine> Get()
        {
            return med_context.MedicineReq.ToList();
        }

        // CREATE
        [HttpPost]
        public string Post([FromBody] Medicine message)
        {
            this.med_context.MedicineReq.Add(message);
            this.med_context.SaveChanges();
            return "Message sent successfully!";
        }

        // DETAILS
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public Medicine Get(int id)
        {
            return this.med_context.MedicineReq.Where(req => req.Id == id).FirstOrDefault();
        }

        // DELETE
        // [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.med_context.MedicineReq.Remove(this.med_context.MedicineReq.Where(req => req.Id == id).FirstOrDefault());
            this.med_context.SaveChanges();
        }
    }
}
