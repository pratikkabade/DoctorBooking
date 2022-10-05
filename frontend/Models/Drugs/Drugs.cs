using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace frontend.Models
{
    public class Drugs
    {
        [Key]
        public int DrugId { get; set; }

        public string Name { get; set; }
        public string Manufacturer { get; set; }

        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public int Quantities { get; set; }
        public string Location { get; set; }


        // ADVANCED
        public Users User { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }

        // public Order Order { get; set; }
        // public int TransactionId { get; set; }
    }
}
