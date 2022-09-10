using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class UserDrug
    {
        public int TransactionId { get; set; }

        // BASIC DATA FIELD 
        public int DrugId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantities { get; set; }
        public string Location { get; set; }


        // ADVANCED
        public Users User { get; set; }
        public Drugs Drug { get; set; }
        // public Order Order { get; set; }


        // BASIC DATA FIELD
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
