using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class UserOrder
    {
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
        // public Drugs Drug { get; set; }
        public Order Order { get; set; }

        // BASIC DATA FIELD
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}
