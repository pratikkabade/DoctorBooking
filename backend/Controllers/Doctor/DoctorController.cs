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
    public class DoctorController : Controller
    {
        private DataBaseContext doc_context;
        public DoctorController(DataBaseContext doc_context)
        {
            this.doc_context = doc_context;
        }

        // INDEX
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IEnumerable<Doctor> Get()
        {
            return doc_context.DoctorReq.ToList();
        }

        // CREATE
        [HttpPost]
        public string Post([FromBody] Doctor message)
        {
            this.doc_context.DoctorReq.Add(message);
            this.doc_context.SaveChanges();
            return "Message sent successfully!";
        }

        // DETAILS
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public Doctor Get(int id)
        {
            return this.doc_context.DoctorReq.Where(req => req.Id == id).FirstOrDefault();
        }

        // DELETE
        // [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.doc_context.DoctorReq.Remove(this.doc_context.DoctorReq.Where(req => req.Id == id).FirstOrDefault());
            this.doc_context.SaveChanges();
        }
    }
}
