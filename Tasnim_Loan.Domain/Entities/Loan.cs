﻿    //using Tasnim_Loan.Domain.Entities.Commons;
using Tasnim_Loan.Domain.Entities.Commons;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasnim_Loan.Domain.Entities
{
    public class Loan : BaseEntity
    {

        [Required]
        public int Total_Amount { get; set; }
        [Required]
        public int Loan_Num { get; set; }
        [Required]
        public int Payment_Num { get; set; }
        [Required]
        public int Payment_Amount { get; set; }
        public string Guaranty { get; set; }
        public string Introducer { get; set; }
        [Required]
        public string Closed { get; set; }
        [Required]
        public string Cleared { get; set; }

        public DateTime Cleared_Date { get; set; }

        [Required]
        public int Customer_ID { get; set; }

        [Required]
        public int User_ID { get; set; }

        [ForeignKey("User_ID")]
        public User User { get; set; }  // Navigation property for the user associated with this loan
        
        
        [ForeignKey("Customer_ID")]
        public Customer Customers { get; set; }
    }
}
