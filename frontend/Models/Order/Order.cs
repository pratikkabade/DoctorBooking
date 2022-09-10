using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace frontend.Models
{
    public class Order
    {
        [Key]
        public int TransactionId { get; set; }

        // BASIC DATA FIELD 
        public long MemberId { get; set; }
        public long Insurance_Policy_Number { get; set; }
        public string InsuranceProvider { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public int DosageForDay { get; set; }
        public string PrescriptionCourse { get; set; }
        public string DoctorDetails { get; set; }

        // ADVANCED
        public Users User { get; set; }
        public int UserId { get; set; }

        public string Email { get; set; }
        // public Drugs Drug { get; set; }
        // public int DrugId { get; set; }
    }
}
