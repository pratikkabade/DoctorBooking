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
    public class DrugsController : Controller
    {
        private DataBaseContext data_context;
        public DrugsController(DataBaseContext data_context)
        {
            this.data_context = data_context;
        }


        // CREATE
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public string Post([FromBody] Drugs drug_name)
        {
            this.data_context.Drug.Add(drug_name);
            this.data_context.SaveChanges();
            return "Drugs created successfully!";
        }


        // INDEX
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IEnumerable<Drugs> Get()
        {
            return data_context.Drug.ToList();
        }


        // GET BY ID
        [HttpGet("no-auth")]
        public IEnumerable<UserDrug> NoAuth()
        {
            var usersDrug = from u in data_context.Set<Users>()
                            join d in data_context.Set<Drugs>()
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

        // GET BY ID
        [HttpGet("id/{id}")]
        public IEnumerable<Drugs> Get(int id)
        {
            return data_context.Drug.Where(drug => drug.UserId == id).ToList();
        }

        // GET BY NAME
        [HttpGet("name/{name}")]
        public Drugs GetName(string name)
        {
            return this.data_context.Drug.Where(drug => drug.Name == name).FirstOrDefault();
        }

        // GET BY NAME
        [HttpGet("location/{location}")]
        public Drugs GetLocation(string location)
        {
            return this.data_context.Drug.Where(drug => drug.Location == location).FirstOrDefault();
        }

        // GET DRUGS
        [HttpGet("Email/{email}")]
        public IEnumerable<UserDrug> GetEmail(string email)
        {
            var usersDrug = from u in data_context.Set<Users>()
                            join d in data_context.Set<Drugs>()
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
            return usersDrug.ToList().Where(drug => drug.Email == email);
        }




        // EDIT
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Drugs drug_name)
        {
            this.data_context.Drug.Update(drug_name);
            this.data_context.SaveChanges();
        }


        // DELETE
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.data_context.Drug.Remove(this.data_context.Drug.Where(drug_name => drug_name.DrugId == id).FirstOrDefault());
            this.data_context.SaveChanges();
        }
    }
}
